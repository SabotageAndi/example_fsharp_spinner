
namespace spinner

open System
open System.Collections.Generic
open System.Linq
open System.Text

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Util
open Android.Views
open Android.Widget

type itemView =
    inherit View
    new (context, attrs, defStyle) as x = { inherit View(context, attrs, defStyle) } then x.Initialize()
    new (context:Context, attrs:IAttributeSet) as x = { inherit View(context, attrs) } then x.Initialize()
    new (context:Context) as x = { inherit View(context) } then x.Initialize()

    member x.Initialize () = ()


