# BindingNavigatorWpf

I wondering when I can't find binding navigator for WPF as I like to use in WinForms.
So I decided to write my own and share it.

I oriented to my needs - binding navigator for related data grid with MVVM support.

I try to write it as simple as possible that anyone can understood and use it.

In addition there is the demo application. I plan to migrate all projects to .NET Core someday.

## Download

Use Visual Studio Nuget Package manager and search `BindingNavigator` or use package manager command 

>Install-Package BindingNavigator -Version 1.0.7.7
>- *replace version with actual one*

Alternatively you can download DLL or Nuget package from [Release Notes](ReleaseNotes.md) directly


## How it look

![Binding Navigator](docs/images/BindingNavigator.jpg)
Where is
1 - first item
2 - previous item
3 - current pos 1..n. Go to position <Enter>
4 - items count
6 - next item
6 - last item
7 - add item
8 - remove item
9 - save item

Buttons 7,8,9 could be hidden over XAML with attribute `VisibilityCommandName`

*Sample*
>VisibilitySave = "False"
>
>VisibilityDelete = "False"

### Demo application

![Demo Screen](docs/images/demo-screen.png)

## Additional information

[How to use](/docs/usage.md)

[How to implemented](/docs/design.md)
