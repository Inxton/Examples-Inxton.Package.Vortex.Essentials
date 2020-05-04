![Inxton logo](./assets/logo.png)

If you have ever struggled to maintain your HMI in synch with your PLC program, you should continue reading. This repo presents a unique library that bring PLC blocks into compelling visual form.
Maintaining the UI/HMI that involves PLC can be very expensive, especially when there are many conflicting requirements throughout the life cycle of the application. Inxton comes with an answer that allows you to scale your solution quickly.

# About sample projects

In this repository, you'll find examples that aim o present some key features of the Inxton.Package.Vortex.Essential.

## Recipes

This example shows an example of Recipe user control that stores, retrieves, uploads, and keeps track of changes.

~~~ XML
<!-- Renderable content control that displays _recipe object with presentation type 'Settings' this means that the renderer will choose View 'stRecipeSettingsView' and ViewMode 'stRecipeSettingsViewModel'-->
<vortex:RenderableContentControl DataContext="{Binding PLC.RecipeData._recipe}" PresentationType="Settings">
<!-- This will override default root container (StackPanel) with Grid -->
    <vortex:RenderableContentControl.RootContainer>
        <Grid/>
    </vortex:RenderableContentControl.RootContainer>
</vortex:RenderableContentControl>
~~~

## Recipe user control

If you need to have more complex logic behind UI user controls you can use MVVM pattern. The rendering system will detect that a ```View``` has respective ```ViewModel``` and that ```ViewModel``` will be automatically set as ```DataContext``` of given ```View```. When there is a view that does not have corresponding ViewModel class, the  renderer will set DataContext the instance of the TwinObject.

```stRecipeSettingsView``` will have DataContext ```stRecipeSettingsViewModel```

You can see that the recipe user control has some more complex features of which the logic is placed in the ViewModel class.

### Things to note in this example

Instead of using ```RenderableContentControl``` we are using C# code to generate the UI. The ```View``` contains simple ```ContentControl``` that binds to the property ```DataPresentation```

~~~ XML
   <GroupBox Header="Data"
             Grid.Row="1"
             Margin="5">
             <ScrollViewer>
                    <ContentControl Content="{Binding DataPresentation}"/>
             </ScrollViewer>
    </GroupBox>
~~~

```DataPresentation``` property is set in ```ViewModel``` object, by selecting editable or readonly form.

~~~ C#
private const string DisplayModePresentationType = "ShadowDisplay";

private const string EditModePresentationType = "ShadowControl";

private void EditDataMode()
{
     this.DataPresentation = LazyRenderer.Get.CreatePresentation(EditModePresentationType, this.Recipe);
     this.SetUpLogging();
     this.LockRecipeSelection = true;
}

private void DisplayDataMode()
{
    this.DataPresentation = LazyRenderer.Get.CreatePresentation(DisplayModePresentationType, this.Recipe);
    this.LockRecipeSelection = false;
}


~~~


In order to quickly check the way the recipe system will scale uncomment the code in ```stRecipe``` structure. Run the compiler, load program to the PLC and run the application. you should get result shown bellow.


**Prior to modification**

~~~ 
TYPE stRecipe :
STRUCT
	{attribute addProperty Name "<#Recipe name#>"}
	_recipeName : STRING;
	{attribute addProperty Name "<#Description#>"}
	_description : STRING(255);
	// Uncomment following lines run the comiler and check that the fiels are added to the UI, and you can save and retrieve the newly added variables.
	(*{attribute addProperty Name "<#Lenght#> [mm]"}
	_lenght : stContinuousValueLimits;
	{attribute addProperty Name "<#Height#> [mm]"}
	_height : stContinuousValueLimits;
	{attribute addProperty Name "<#Thickness#> [mm]"}
	_thikness : stContinuousValueLimits;*)
END_STRUCT
END_TYPE
~~~

![Inxton logo](./assets/recipe_00.png)


**After modification**
~~~
TYPE stRecipe :
STRUCT
	{attribute addProperty Name "<#Recipe name#>"}
	_recipeName : STRING;
	{attribute addProperty Name "<#Description#>"}
	_description : STRING(255);
	{attribute addProperty Name "<#Lenght#> [mm]"}
	_lenght : stContinuousValueLimits;
	{attribute addProperty Name "<#Height#> [mm]"}
	_height : stContinuousValueLimits;
	{attribute addProperty Name "<#Thickness#> [mm]"}
	_thikness : stContinuousValueLimits;
END_STRUCT
END_TYPE
~~~

![Inxton logo](./assets/recipe_01.png)

# License

TLDR
> You can use Inxton.Vortex.Framework free of charge, although when you want to use it in a production environment you need to go to  [INXTON.com](https://www.inxton.com/) and purchase a license.

To make our lawyers happy - read the whole license agreement [here](https://github.com/Inxton/about/blob/master/license.md)


## What to do next?

Check out the documentation  [Inxton.Package.Vortex.Core](https://github.com/Inxton/Inxton.Package.Vortex.Core)

Install the extension from [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=Inxton.InxtonVortexBuilderExtensionPre)


---
Developed with ♥ at [MTS](https://www.mts.sk/en) - putting the heart into manufacturing.
 
