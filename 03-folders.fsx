#r "System.Xml.Linq.dll"
open System.Xml.Linq
open System.Linq
open System.IO

// XML Namespaces
let xmlNS = XName.Get
let xmlWP name = XName.Get (name, "http://wordpress.org/export/1.2/")

// XML Function Utils
let GetDescendent name (doc: XDocument) = doc.Descendants(xmlNS name)
let GetChild (item: XElement) name = item.Element(xmlNS name).Value

// Verify if the item is a post indeed
let IsPost (item: XElement) = (item.Element(xmlWP "post_type").Value = "post")
let IsPublished (item: XElement) = (item.Element(xmlWP "status").Value = "publish")

// Just do it!
let FindTitleLink (item: XElement) = (GetChild item "title" , GetChild item "link" )
let GenerateHtml (t: string,l: string) = XElement(xmlNS "a", t,
                                            XAttribute(xmlNS "link", l))
let TransformHtml (item: XElement) = (FindTitleLink item) |> GenerateHtml

let elements = 
    "input\\sqlblogninja.wordpress.xml" 
    |> XDocument.Load
    |> GetDescendent "item"
    |> Seq.filter( IsPost )
    |> Seq.filter( IsPublished )
    |> Seq.map( TransformHtml )

XDocument( 
    XElement(xmlNS "posts", elements ))
    |> fun doc -> doc.Save "output\\postlist.xml"

let xmlContent name = XName.Get (name, "http://purl.org/rss/1.0/modules/content/")

let GetChildContent (item: XElement) = item.Element(xmlContent "encoded").Value
let FindTitleLinkContent (item: XElement) = (GetChild item "title" , GetChild item "link", GetChildContent item)

let GenerateHtmlWithContent (t: string,l: string, c:string) = 
    XElement(xmlNS "div",
        XElement(xmlNS "a", t,
            XAttribute(xmlNS "link", l)
            ),
        XElement(xmlNS "div", c)
        )

let TransformHtmlWithContent (item: XElement) = (FindTitleLinkContent item) |> GenerateHtmlWithContent

let CreateFileName (linkbase: string) (link: string)  =
    link.Substring(linkbase.Length).TrimEnd('/').Replace('/', '-').Replace('%', '-')

let SaveContent (title, link, content)=
    let name = (CreateFileName "https://blogs.msdn.microsoft.com/fcatae/" link)
    let filename = sprintf "output\\folders\\%s\\readme.md" name
    let header = sprintf "<a link='%s'>%s</a>" link title
    File.WriteAllLines( filename , [header; content]) 

let CreateFolder (t,link,c) =
    let foldername = sprintf "output\\folders\\%s" (CreateFileName "https://blogs.msdn.microsoft.com/fcatae/" link)
    Directory.CreateDirectory foldername |> ignore
    (t,link,c)

let elementsWithContentDefinition = 
    "input\\sqlblogninja.wordpress.xml" 
    |> XDocument.Load
    |> GetDescendent "item"
    |> Seq.filter( IsPost )
    |> Seq.filter( IsPublished )
    |> Seq.map( FindTitleLinkContent )

let elementsWithContent = elementsWithContentDefinition.ToArray()

elementsWithContent
    |> Seq.map( CreateFolder >> SaveContent )

