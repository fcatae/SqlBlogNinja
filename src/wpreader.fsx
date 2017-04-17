#r "System.Xml.Linq.dll"

open System.Xml.Linq
open System.Linq
open System.IO

type WPReaderBlog (node: XElement) =

    // XML Namespaces
    static let xmlNS = XName.Get
    static let xmlWP name = XName.Get (name, "http://wordpress.org/export/1.2/")

    // XML Function Utils    
    let getChild name = node.Element(name).Value
    // let _title = getChild (xmlNS "title")
    // let _link = getChild (xmlNS "link")
    
    // Methods
    member this.IsPost = (node.Element(xmlWP "post_type").Value = "post")
    member this.IsPublished = (node.Element(xmlWP "status").Value = "publish")
    member this.Title = getChild (xmlNS "title")
    member this.Link = getChild (xmlNS "link")

    member this.Categories = node.Elements(xmlNS "category")
                                |> Seq.filter( fun category -> category.Attribute(xmlNS "domain").Value = "category" )
                                |> Seq.map( fun category -> category.Value )
                                |> Seq.toArray

//<category domain="category" nicename="sql"><![CDATA[SQL]]></category>

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



let elements = 
    "input\\sqlblogninja.wordpress.xml" 
    |> WPReader.LoadPosts
    |> Seq.filter( fun post -> post.IsPost && post.IsPublished )
    //|> Seq.map( fun post -> (post.Title, post.Link, post.Categories ) )
    //|> Seq.take 10
    //|> Seq.toArray

let categoryIndex =
    seq { for item in elements do
            for category in item.Categories do
                yield (category, item)
    }
    //|> Seq.filter( fun (cat,item) -> cat <> "SQL" )
    |> Seq.groupBy( fun (cat,item) -> cat )
    |> Seq.sortBy( fun (cat,item) -> cat )    
    |> Seq.toArray

let printFile = 
    let lines = seq {
        for (category, posts) in categoryIndex do
            yield sprintf "Category: %s" category
            yield ""
            // loop each entry
            for (_,post) in posts do
                yield sprintf "- [%s](%s)" post.Title post.Link
                yield ""
    }
    File.WriteAllLines("index.md", lines)
    