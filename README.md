# Playmaker Actions
Custom Actions for Playmaker (Unity)

## Axis (Raw) To Velocity 2d
Two actions, one using GetAxis, the other GetAxisRaw. This is a kind of basic movement controller for 2d games. The action gets the axis value (i.e. player input), multiplies it with a value and powers velocity 2D with it. It can also fire off events based on direction, which is useful to flip the sprites. *Axis To Velocity 2d* uses the smoothed values. *Axis Raw To Velocity 2d* doesn't use smoothing and results in a 'snappier' game feel. See Unity documentation on Input.GetAxis and Input.GetAxisRaw for more information.

## Color Mix
You can tint sprites using the color field in the inspector. This action makes it possible to tint "just a bit" towards a second color, that is mixing colors together, which is useful when you want to change the amount of tint based on some gameplay parameter, e.g. health bar changing color based on HP left, or when sprites use different "base" colours and you want to tint them a bit (for example to fake distance blue)

## Get Axis Raw
My cheaply adapted version that uses Input.GetAxisRaw instead of Input.GetAxis. The axis raw value returns either -1 (when the axis is down or left), 0 (neutral) or +1 (up or right), and stores the value in a float. This results in a snappier, but also less smooth input. See Unity documentation on Input.GetAxis and Input.GetAxisRaw for more information. Also see next action

## Get Axis Raw Switch
Combines both *Get Axis* and *GetAxisRaw* in one action, with a bool to change which version is used. This is intended to be a prototype action to play around and get a sense of what works best, because normally you'll settle for one type. 

## Get Axis To Button Down (Store)
Take the axis you provide, and treat the directions as buttons ("Negative Button" and "Positive Button", and also the alternatives as listed in Input Manager). To do this right now, you would get the axis, store it into a variable, and then feed it into a float compare. This makes it in one go. The store version can also store if the button was pressed (it's a bit sleeker, but won't make much of a difference on performance).

## Get Button Down And Axis
You look for a simple way for Button+Direction input? When a Button is pressed, sends an event based on current axis direction, i.e. up+button, left+button for fighting games, combos etc. If you only want to use one direction (say, only up+button), simple leave the other one (down+button) blank.

## Get Flip Orientation
Typically, in side-scrollers, sprites are flipped by setting their scale to -1. This action is tailor-made to simply check that value to find out in which direction the sprite is facing.

## Get Relative Direction 2D (Events)
Two actions, one with extra events, one without. You provide an origin GameObject, and a target. It calculates the direction and distance, as X and Y separated. When the target is left or down from origin, it returns the distances as negative numbers. I.e. -2/-2 means two leftwards and two downwards. When you want the total distance, try GetDistance (provided, or Ecosystem). The one with events also has, unsurpringsly, events that are fired based off direction. For how the values are interpreted, see the forum post. http://hutonggames.com/playmakerforum/index.php?topic=19490

## SVG Set Order In Layer
Set the 'Order in Layer' property in a SVG Importer SpriteRenderer. That's the original SVG Importer (paid asset), not the one that Unity is developing and confusingly named the same way.

## SVG Sprite Color
Set the color property in a SVG SpriteRenderer. That's the original SVG Importer (paid asset), not the one that Unity is developing and confusingly named the same way.

## Set Order In Layer
As it says on the tin: Gets the SpriteRenderer of suitable GameObject, and sets the "Order in Layer" property to an integer you provide. 

## Set Rigid Body Type 2D
Allows to change Body Type and Simulated parameters of a Rigidbody 2D, e.g. from dynamic to kinematic and back.
