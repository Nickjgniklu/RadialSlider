# RadialSlider
A simple Radial Slider for Xamarin Forms similar to the standard Xamarin Forms slider.  


![Demo Image](https://raw.githubusercontent.com/Nickjgniklu/RadialSlider/master/demo.gif?raw=true)

`
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             xmlns:radialslider="clr-namespace:Plugin.RadialSlider;assembly=Plugin.RadialSlider"
             mc:Ignorable="d"
             x:Class="RadialSliderDemo.MainPage">

    <StackLayout Orientation="Vertical">
        <radialslider:RadialSlider
        x:Name="MyRadialSilder"
        ArcBackgroundColor="Gray"
        ArcColor="OrangeRed"
        KnobColor="White"
        Value="{Binding Source={x:Reference slider},Path=Value,Mode=TwoWay}"
        ValueChanged="RadialSlider_ValueChanged"
        Min="0"
        Max="255"
        ShowValue="True"
        VerticalOptions="FillAndExpand"
        ></radialslider:RadialSlider>
        <Slider  x:Name="slider" Minimum="0" Maximum="255" HorizontalOptions="FillAndExpand"></Slider>

    </StackLayout>
</ContentPage>

`

Feel free to create Issues and Pull Requests!
