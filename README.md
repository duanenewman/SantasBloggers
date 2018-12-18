# SantasBloggers
This is a demo for my [blog post](http://duanenewman.net/blog/post/keeping-observable-collections-up-to-date/)

This highlights using my IListExtensions.UpdateItems extension method to keep an ObservableCollection up to date with data coming from an API in a generic way without recreating the list each time. The general idea is to lower the load on CPU/memory from object creation/destruction and improve UI responsiveness by reducing the load on DataTemplate cycling.
