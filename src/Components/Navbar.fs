[<RequireQualifiedAccess>]
module Components.Navbar

open Lit
open Browser.Types
open Types

// uncomment the following lines to reproduce
//
// let MouseController: obj =
//     Fable.Core.JsInterop.importMember "../Controllers/controllers.js"

// [<Fable.Core.Emit("new MouseController($0)")>]
// let createMouseCtrl host : {| x: float; y: float |} = Fable.Core.Util.jsNative


[<LitElement("flit-navbar")>]
let private NavBar () =

    let host = LitElement.init ()
    // the controller gets added to
    // the host every time there is a re-render
    // let mouseCtrl = createMouseCtrl host

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
        // uncomment and move this line to the html string
        //Cursor Position: {mouseCtrl.x} - {mouseCtrl.y}
        $"""
    <button @click={goback}>Back</button>
    <button @click={gotoPage Page.Home}>Home</button>
    <button @click={gotoPage Page.Notes}>Notes</button>
  """

let register () = ()
