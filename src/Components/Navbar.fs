[<RequireQualifiedAccess>]
module Components.Navbar

open Lit
open Browser.Types
open Types


let MouseController: obj =
    Fable.Core.JsInterop.importMember "../Controllers/controllers.js"

[<Fable.Core.Emit("new MouseController($0)")>]
let createMouseCtrl host : {| x: float; y: float |} = Fable.Core.Util.jsNative


[<LitElement("flit-navbar")>]
let private NavBar () =

    let host = LitElement.init ()

    let mouseCtrl = createMouseCtrl host

    let goback (ev: Event) =
        let evt =
            createEvent
                "go-back"
                {| bubbles = true
                   cancelable = true
                   composed = true |}

        ev.target.dispatchEvent (evt)

    let gotoPage page (ev: Event) =
        let evt =
            createCustomEvent
                "go-to-page"
                {| bubbles = true
                   cancelable = true
                   composed = true
                   detail = page |}

        ev.target.dispatchEvent evt

    html
        $"""
    <button @click={goback}>Back</button>
    <button @click={gotoPage Page.Home}>Home</button>
    <button @click={gotoPage Page.Notes}>Notes</button>
    Cursor Position: {mouseCtrl.x} - {mouseCtrl.y}
  """

let register () = ()
