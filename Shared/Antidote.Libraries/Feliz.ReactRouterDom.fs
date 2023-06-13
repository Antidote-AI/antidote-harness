module Feliz.ReactRouterDom

open Fable.Core
open Fable.Core.JsInterop
open Feliz

type IRoutesProperty =
    interface end

type IRouteProperty =
    interface end

type IOutletProperty =
    interface end

type ILinkProperty =
    interface end

type IBrowserRouter =
    interface end

type INavigateProperty =
    interface end

[<Erase>]
type reactRouterDom =

    static member inline routes (properties: #IRoutesProperty list) =
        Interop.reactApi.createElement(import "Routes" "react-router-dom", createObj !!properties)

    static member inline routes (children: #seq<ReactElement>) =
        Interop.reactApi.createElement(
            import "Routes" "react-router-dom",
            (
                createObj
                    [
                        "children" ==> Interop.reactApi.Children.toArray (Array.ofSeq children)
                    ]
            )
        )

    static member inline route (properties: #IRouteProperty list) =
        Interop.reactApi.createElement(import "Route" "react-router-dom", createObj !!properties)

    static member inline outlet (properties: #IOutletProperty list) =
        Interop.reactApi.createElement(import "Outlet" "react-router-dom", createObj !!properties)

    static member inline link (properties: #ILinkProperty list) =
        Interop.reactApi.createElement(import "Link" "react-router-dom", createObj !!properties)

    static member inline browserRouter (properties: #IBrowserRouter list) =
        Interop.reactApi.createElement(import "BrowserRouter" "react-router-dom", createObj !!properties)


    static member inline browserRouter (children : #seq<ReactElement>) =
        Interop.reactApi.createElement(
            import "BrowserRouter" "react-router-dom",
            (
                createObj
                    [
                        "children" ==> Interop.reactApi.Children.toArray (Array.ofSeq children)
                    ]
            )
        )

    static member inline navigate (properties: #INavigateProperty list) =
        Interop.reactApi.createElement(import "Navigate" "react-router-dom", createObj !!properties)

module Interop =

    let inline mkRoutesAttr (key: string) (value: obj) : IRoutesProperty = unbox (key, value)

    let inline mkRouteAttr (key: string) (value: obj) : IRouteProperty = unbox (key, value)

    let inline mkOutletAttr (key: string) (value: obj) : IOutletProperty = unbox (key, value)

    let inline mkLinkAttr (key: string) (value: obj) : ILinkProperty = unbox (key, value)

    let inline mkBrowserRouterAttr (key: string) (value: obj) : IBrowserRouter = unbox (key, value)

    let inline mkNavigateAttr (key: string) (value: obj) : INavigateProperty = unbox (key, value)

[<Erase>]
type route =
    static member inline path (path: string) =
        Interop.mkRouteAttr "path" path

    static member inline element (element: ReactElement) =
        Interop.mkRouteAttr "element" element

    static member inline children (children: #seq<ReactElement>) =
        Interop.mkRouteAttr "children" children

    static member inline index =
        Interop.mkRouteAttr "index" true

[<Erase>]
type link =
    static member inline To (path: string) =
        Interop.mkLinkAttr "to" path

    static member inline ``to`` (path: string) =
        Interop.mkLinkAttr "to" path

    static member inline children (children: #seq<ReactElement>) =
        Interop.mkLinkAttr "children" children

[<Erase>]
type navigate =
    static member inline To (path: string) =
        Interop.mkNavigateAttr "to" path

    static member inline state (state: obj) =
        Interop.mkNavigateAttr "state" state

    static member inline replace =
        Interop.mkNavigateAttr "replace" true

[<Erase>]
type outlet =
    static member inline context (value : obj) =
        Interop.mkOutletAttr "context" value

module rec Types =

    /// <summary>
    /// A unique string associated with a location. May be used to safely store
    /// and retrieve data in some other storage API, like <c>localStorage</c>.
    /// </summary>
    /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.key" />
    type Key =
        string

    /// <summary>A URL pathname, beginning with a /.</summary>
    /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.pathname" />
    type Pathname =
        string

    /// <summary>A URL search string, beginning with a ?.</summary>
    /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.search" />
    type Search =
        string

    /// <summary>A URL fragment identifier, beginning with a #.</summary>
    /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.hash" />
    type Hash =
        string

    /// <summary>
    /// An entry in a history stack. A location contains information about the
    /// URL path, as well as possibly some arbitrary state and a key.
    /// </summary>
    /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location" />
    type [<AllowNullLiteral>] Location =
        inherit Path
        /// <summary>A value of arbitrary data associated with this location.</summary>
        /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.state" />
        abstract state: obj with get, set
        /// <summary>
        /// A unique string associated with this location. May be used to safely store
        /// and retrieve data in some other storage API, like <c>localStorage</c>.
        ///
        /// Note: This value is always "default" on the initial location.
        /// </summary>
        /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.key" />
        abstract key: Key with get, set

    /// The pathname, search, and hash values of a URL.
    type [<AllowNullLiteral>] Path =
        /// <summary>A URL pathname, beginning with a /.</summary>
        /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.pathname" />
        abstract pathname: Pathname with get, set
        /// <summary>A URL search string, beginning with a ?.</summary>
        /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.search" />
        abstract search: Search with get, set
        /// <summary>A URL fragment identifier, beginning with a #.</summary>
        /// <seealso href="https://github.com/remix-run/history/tree/main/docs/api-reference.md#location.hash" />
        abstract hash: Hash with get, set

    /// The interface for the navigate() function returned from useNavigate().
    type [<AllowNullLiteral>] NavigateFunction =
        [<Emit "$0($1...)">] abstract Invoke: ``to``: To * ?options: NavigateOptions -> unit
        [<Emit "$0($1...)">] abstract Invoke: ``to``: string * ?options: NavigateOptions -> unit
        [<Emit "$0($1...)">] abstract Invoke: ``to``: Path * ?options: NavigateOptions -> unit
        [<Emit "$0($1...)">] abstract Invoke: delta: float -> unit

    [<Global>]
    type NavigateOptions [<ParamObject; Emit "$0">] (?replace : bool, ?state : obj) =
        member val replace: bool option = jsNative with get, set
        member val state: obj option = jsNative with get, set

    type To =
        U2<string, obj>

let useLocation () : Types.Location =
    import "useLocation" "react-router-dom"

let useNavigate () : Types.NavigateFunction =
    import "useNavigate" "react-router-dom"

let useParams<'T> () : 'T =
    import "useParams" "react-router-dom"

let useOutletContext<'T> () : 'T =
    import "useOutletContext" "react-router-dom"
