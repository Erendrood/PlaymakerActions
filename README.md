# Playmaker Actions
These are my custom actions for Playmaker (Unity).

## Axis (Raw) To Velocity 2d
Two actions, one using GetAxis, the other GetAxisRaw. This is a kind of basic movement controller for 2d games. The action gets the axis value (i.e. player input), multiplies it with a value and powers velocity 2D with it. It can also fire off events based on direction, which is useful to flip the sprites. *Axis To Velocity 2d* uses the smoothed values. *Axis Raw To Velocity 2d* doesn't use smoothing and results in a 'snappier' game feel. See Unity documentation on [Input.GetAxis](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html) and [Input.GetAxisRaw](https://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html) for more information. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19504)

## Color Mix
You can tint sprites using the color field in the inspector. This action makes it possible to tint "just a bit" towards a second color, that is mixing colors together, which is useful when you want to change the amount of tint based on some gameplay parameter, e.g. health bar changing color based on HP left, or when sprites use different "base" colours and you want to tint them a bit (for example to fake distance blue). [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19454)

## Get Axis Raw
My cheaply adapted version that uses Input.GetAxisRaw instead of Input.GetAxis. The axis raw value returns either -1 (when the axis is down or left), 0 (neutral) or +1 (up or right), and stores the value in a float. This results in a snappier, but also less smooth input. See Unity documentation on [Input.GetAxis](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html) and [Input.GetAxisRaw](https://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html) for more information.. Also see next action. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19333)

## Get Axis Raw Switch
Combines both *Get Axis* and *GetAxisRaw* in one action, with a bool to change which version is used. This is intended to be a prototype action to play around and get a sense of what works best, because normally you'll settle for one type. See Unity documentation on [Input.GetAxis](https://docs.unity3d.com/ScriptReference/Input.GetAxis.html) and [Input.GetAxisRaw](https://docs.unity3d.com/ScriptReference/Input.GetAxisRaw.html) for more information. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19333)

## Get Axis To Button Up/Down (Store)
Take the axis you provide, and treat the directions as buttons ("Negative Button" and "Positive Button", and also the alternatives as listed in Input Manager). Button down is when the axis is moved in the direction, and button up is when the axis is released from direction. One set is simple, the variants with ...Store has a few more options to store presses/releases in bools. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19499)

## Get Button Down And Axis
You look for a simple way for Button+Direction input? When a Button is pressed, sends an event based on current axis direction, i.e. up+button, left+button for fighting games, combos etc. If you only want to use one direction (say, only up+button), simply leave the other one (down+button) blank.

## Get Flip Orientation
Typically, in side-scrollers, sprites are flipped by setting their scale to -1. This action is tailor-made to simply check that value to find out in which direction the sprite is facing.

## Get Relative Direction 2D (Events)
Two actions, one with extra events, one without. You provide an origin GameObject, and a target. It calculates the direction and distance, as X and Y separated. When the target is left or down from origin, it returns the distances as negative numbers. I.e. -2/-2 means two leftwards and two downwards. When you want the total distance, try GetDistance (provided, or Ecosystem). The one with events also has, unsurpringsly, events that are fired based off direction. For how the values are interpreted, see the forum post. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19490)

## Puppet2D Flip
If you are using Puppet2D, you probably want to flip the character to move in the opposite direction. This tiny action will help you do that. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=14906)

## SVG Set Order In Layer
Set the 'Order in Layer' property in a SVG Importer SpriteRenderer. That's the original SVG Importer (paid asset), not the one that Unity is developing and confusingly named the same way.

## SVG Sprite Color
Set the color property in a SVG SpriteRenderer. That's the original SVG Importer (paid asset), not the one that Unity is developing and confusingly named the same way.

## Set Distance Joint 2D
An action to set everything of the Distance Joint component panel as it is, plus "enable" of the entire component for good measure. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19536)

## Set Order In Layer
As it says on the tin: Gets the SpriteRenderer of suitable GameObject, and sets the "Order in Layer" property to an integer you provide. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19379)

## Set Parent 3
There were 2 versions of set parent already. Uses another method, which was suggested by Unity when setting parent inside canvas. Better use the other versions, unless you got the same issue. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19470)

## Set Platform Effector 2D
The action to set almost everything in a Platform Effector 2D. To add/remove from Collider Mask, use Platform Effector 2D Collider Mask action. (from Ecosystem).

## Set Rigid Body Type 2D
Allows to change Body Type and Simulated parameters of a Rigidbody 2D, e.g. from dynamic to kinematic and back. [PM Forum Post](http://hutonggames.com/playmakerforum/index.php?topic=19487)
