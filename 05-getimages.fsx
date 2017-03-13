
#r """packages\FSharp.Data\lib\net40\FSharp.Data.dll"""

open FSharp.Data;

Http.Request("https://blogs.msdn.microsoft.com/fcatae/2009/08/21/a-mecnica-de-um-disk-drive/")




open System.IO
open System.Linq;
open System.Text.RegularExpressions

let FOLDERPATH = "output\\folders\\"
let INDEXFILENAME = "readme.md"

let ListFolders = FOLDERPATH |> Directory.EnumerateDirectories

ListFolders.ToArray()

let CreateImageDirectory name =
    let imagename = (name + "\\images")
    Directory.CreateDirectory imagename |> ignore
    imagename

let ReadIndexHtml path =
    let indexfile = sprintf "%s\\%s" path INDEXFILENAME
    File.ReadAllText indexfile

let reg = Regex("""["'](http[s]?:/\S*/(\S*\.(png|gif|jpg|jpeg)))["']""" , RegexOptions.IgnoreCase)

reg.Matches "'http://img.html'"
reg.Matches "'http://img.png'"
reg.Matches "'http://f/img.png'"



let CreateImageName basepath imagepath = (sprintf "%s\\images\\%s" basepath imagepath)

let DownloadFile (src, _, dst) =

    printfn "Download file: %s" src
    let response = Http.Request(src)

    match response.Body with
        | Binary(image)     ->  File.WriteAllBytes(dst, image)
                                dst
        | _ -> 
            failwith (sprintf "error downloading image [%s] to [%s]" src dst)

DownloadFile ("https://msdnshared.blob.core.windows.net/media/TNBlogsFS/BlogFileStorage/blogs_msdn/fcatae/WindowsLiveWriter/AmecnicadeumDiskDrive_14125/image_2.png",1, "output\\teste.png")

let CreateAllImages basefolder =
    let imagepath = basefolder
                        |> CreateImageDirectory
    let matches = 
        basefolder 
        |> ReadIndexHtml
        |> reg.Matches 
        |> Seq.cast<Match>
        |> Seq.map( fun m -> (m.Groups.[1].Value, m.Groups.[2].Value, imagepath + "\\" +  m.Groups.[2].Value) )
        |> Seq.toArray
        |> Seq.map( DownloadFile )        
        |> Seq.iter( ignore )

    basefolder 
        |> ReadIndexHtml
        |> RewritePage
        |> ignore

    matches


FOLDERPATH 
    |> Directory.EnumerateDirectories
    |> Seq.map( CreateAllImages )
    |> Seq.iter( ignore )

let RewritePage page = reg.Replace(page,  "\"$2\"") 

let basefolder= "output\\folders\\2009-08-21-a-mecnica-de-um-disk-drive"

basefolder
    |> ReadIndexHtml
    |> RewritePage
    |> fun content -> File.WriteAllText(basefolder + "\\index.md", content)
    |> ignore

