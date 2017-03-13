#r "System.Xml.Linq.dll"

open System.Xml.Linq
open System.Linq

type WPReaderBlog (node: XElement) =

    // XML Namespaces
    static let xmlNS = XName.Get
    static let xmlWP name = XName.Get (name, "http://wordpress.org/export/1.2/")

    // XML Function Utils    
    let getChild name = node.Element(name).Value
    let _title = getChild (xmlNS "title")
    let _link = getChild (xmlNS "link")
    
    // Methods
    member this.IsPost = (node.Element(xmlWP "post_type").Value = "post")
    member this.IsPublished = (node.Element(xmlWP "status").Value = "publish")
    member this.Title = _title
    member this.Link = _link



type WPReader()= 

    // XML Namespaces
    static let xmlNS = XName.Get

    // XML Function Utils
    static let GetXmlNodes name (doc: XDocument) = doc.Descendants(xmlNS name)
    let GetChild (item: XElement) name = item.Element(xmlNS name).Value

    static let CreateBlogInfo node =
        WPReaderBlog(node)

    static member LoadPosts (filename: string) =
        filename
        |> XDocument.Load
        |> GetXmlNodes "item"
        |> Seq.map( WPReaderBlog )        



(*


let wp = WPReader("input\\sample.xml")
let (wp1 ) = wp.Process() 
                            |> Seq.filter( fun post -> post.IsPost && post.IsPublished )

let GetXmlNodes name (doc: XDocument) = doc.Descendants(xmlNS name)

let arr ="input\\sample.xml"
        |> XDocument.Load
        |> GetXmlNodes "item"
        |> Seq.take 1
        |> Seq.toArray

let l = WPReader.CreateBlogInfo arr.[0]

l.IsPost

|> Seq.map( WPReader.CreateBlogInfo )
*)


let elements = 
    "input\\sqlblogninja.wordpress.xml" 
    |> WPReader.LoadPosts
    |> Seq.filter( fun post -> post.IsPost && post.IsPublished )
    |> Seq.map( fun post -> (post.Title, post.Link ) )

    |> Seq.toArray
