namespace spinner

open System

open Android.App
open Android.Content
open Android.OS
open Android.Runtime
open Android.Views
open Android.Widget


type Item =
    {
        Id : int;
        Name : string;
    }    

type SpinnerAdapter (items : Item list, activity : Activity)=
    inherit BaseAdapter ()

    let items = items
    let activity = activity

    override this.GetItem(position : int) =
        null

    override this.GetItemId(position : int) =
        int64 position

    override this.GetView (position, convertView, parent) =
        let view = match convertView with
                   | null -> activity.LayoutInflater.Inflate(Resource_Layout.itemView, null)
                   | _ -> convertView

        let item = List.nth items position
        
        let textView = view.FindViewById<TextView>(Resource_Id.text);
        textView.Text <- item.Name

        view

    override this.get_Count() =
        List.length items
    

[<Activity (Label = "${AppName}", MainLauncher = true, Icon = "@mipmap/icon")>]
type MainActivity () =
    inherit Activity ()

    let data = [
        {Id = 1; Name = "Movie 1"}
        {Id = 2; Name = "Movie 2"}
    ]

    override this.OnCreate (bundle) =

        base.OnCreate (bundle)

        // Set our view from the "main" layout resource
        this.SetContentView (Resource_Layout.Main)


        let arrayAdapter = new SpinnerAdapter(data, this)   

        let spinner = this.FindViewById<Spinner>(Resource_Id.spinner)
        spinner.Adapter <- arrayAdapter

        spinner.ItemSelected.Add(fun args ->
            let selectedItem = List.nth data args.Position
            this.FindViewById<TextView>(Resource_Id.selectedItem).Text <- selectedItem.Name)
