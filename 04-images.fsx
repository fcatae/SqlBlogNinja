
open System.IO
open System.Linq;
open System.Text.RegularExpressions

let FOLDERPATH = "output\\folders\\"
let INDEXFILENAME = "readme.md"

let ListFolders = FOLDERPATH |> Directory.EnumerateDirectories

ListFolders.ToArray()


let folderfullpathname = """output\folders\2009-12-27-estatsticas"""

let CreateImageDirectory name =
    let imagename = (name + "\\images")
    Directory.CreateDirectory imagename |> ignore
    imagename

//let foldername = folderfullpathname.Substring(FOLDERPATH.Length)

let ReadIndexHtml path =
    let indexfile = sprintf "%s\\%s" path INDEXFILENAME
    File.ReadAllText indexfile

let reg = Regex("""["'](http[s]?:/\S*/(\S*\.(png|gif|jpg|jpeg)))["']""" , RegexOptions.IgnoreCase)

reg.Matches "'http://img.html'"
reg.Matches "'http://img.png'"
reg.Matches "'http://f/img.png'"
let CreateImageName basepath imagepath = (sprintf "%s\\images\\%s" basepath imagepath)

let imagepath = """output\folders\2009-12-27-estatsticas"""
                    |> CreateImageDirectory
let matches = 
    folderfullpathname 
    |> ReadIndexHtml
    |> reg.Matches 
    |> Seq.cast<Match>
    |> Seq.map( fun m -> (m.Value, m.Groups.[2].Value, imagepath + "\\" +  m.Groups.[2].Value) )
    |> Seq.iter( fun (_,_,path) -> (File.Create path) |> ignore )


