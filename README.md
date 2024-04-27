# Missing Features

## A bunch of basic missing features

- ### <u>Missing Attributes</u><BR/>

	- **LabelPlus**<BR/>
Custom *Inspector* property label that allows using an icon, a custom label text and a custom label color.

	- **HeaderPlus**<BR/>
Custom *Inspector* property header that allows using an icon, a custom header label text and a custom header label color.

	- **ReadOnlyProp**<BR/>
Prevents a property from being edited on the *Inspector*.

	- **ReadOnlyOnPlay**<BR/>
Prevents a property from being edited on the *Inspector* in *PlayMode*. The behaviour can be inverted so the property is editable only in *PlayMode*.

	- **ReadOnlyOnPrefab**<BR/>
Prevents a property from being edited on the *Inspector* in *PrefabMode*. The behaviour can be inverted so the property is editable only in *PrefabMode*.

	- **HideOnPlay**<BR/>
Hides the property in *PlayMode*. The behaviour can be inverted with the 'invert' parameter so the property is visible only in *PlayMode*.

	- **HideOnPrefab**<BR/>
Hides the property in *PrefabMode*. The behaviour can be inverted with the 'invert' parameter so the property is visible only in *PrefabMode*.

	- **ShowPropIf**<BR/>
Shows or hides a property on the inspector based on another serialized bool property value.

	- **ShowPropConditional**<BR/>
Shows or hides a property based on a bool method.

	- **Tag**<BR/>
Displays a dropdown list of available Tags (must be used with a 'string' typed property).

	- **Layer**<BR/>
Displays a dropdown list of available Layers (must be used with a 'int' typed property).
It offers a single layer selection instead of the multiple LayerMask selection.

	- **Scene**<BR/>
Displays a dropdown list of available build settings Scenes (must be used with a 'string' typed property).

- ### <u>Missing Events</u><BR/>

	- **MouseEvents**<BR/>
Offers UnityEvent fields for Unity's mouse callback methods.

	- **LifeCycleEvents**<BR/>
Offers UnityEvent fields for Unity's lifecycle callback methods.

	- **VisibleEvents**<BR/>
Offers UnityEvent fields for Unity's visible callback methods.

	- **PhysicsEvents**<BR/>
Offers UnityEvent fields for Unity's physics callback methods and sleep state changes.

	- **TimerEvents**<BR/>
Fires UnityEvents based on time.

	- **Events Data Converters**<BR/>
Middleware components to plug between UnityEvent and methods when the type does not match but can be converted.
		- **BooleanReverseEvent** : A component to plug between a UnityEvent\<bool\> and a method that accepts an boolean parameter to reverse its value.
		- **FloatToIntEvent** : A component to plug between a UnityEvent\<float\> and a method that accepts an integer parameter.
		- **ToStringEvent** : A component to plug between a UnityEvent and a method that accepts a string parameter. Supported types are bool, int and float.

- ### <u>Missing Windows</u><BR/>

	- **TimeScale Window**<BR/>
Exposes the main timescale settings.

	- **PhysicsWindow**<BR/>
Exposes the main physics settings.

	- **Scenes Explorer Window**<BR/>
Exposes the scenes assets.

	- **Quick Assets Window**<BR/>
Exposes an custom assets list.

- ### <u>Missing Components</u><BR/>

	- **Destroyer**<BR/>
A component that can destroy objects.

	- **Force Impulser**<BR/>
A component that can apply impulse force on physics objects.

	- **Simple Animators**<BR/>
Components to use for simple A to B automatic animations
		- **SimpleTransformAnimator** : A simple motion animator component for simple Transform animation
		- **SimpleRendererColorAnimator** : A simple color animator component for simple Renderer color animation
		- **SimpleSpriteRendererColorAnimator** : A simple color animator component for simple SpriteRenderer color animation
	
	- **Debug Logger**<BR/>
A component with public methods that you can plug to UnityEvents callback to debug events firing

	- **Color Setters**<BR/>
Simple color setter components meant to be plugged to UnityEvent for setting color without scripting. Works with Renderer and SpriteRenderer.
