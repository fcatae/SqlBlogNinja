
#r "System.Xml.Linq.dll"
open System.Xml.Linq
open System.Linq

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

