# GamedevForge.Hints

GamedevForge.Hints is a Unity package that provides a in-game hints bound to a target object.

![hints](https://github.com/user-attachments/assets/6a497efa-b52a-45ee-9656-e4ce4874e074)


Package is:
- showing UI marker above your target
- showing distance to target (can disable in settings)
- show additional direction image if target outside of camera view


## How to install

Via package manager: press "+" and "Install package from git URL".

Via unity package: go to release tab, download the package and drop it into your unity project.

## API

There is two ways to use hints:
### static API
```csharp
Hints.SetTarget(Transform target);
Hints.Clear();
```
### non-static API
Useful for consistent usage if you use DI or Service Locator in your project.
```csharp
var adapter = new HintsAdapter();
adapter.SetTarget(someTransform);
adapter.Clear();
```

## Setting
Settings locates in Assets/GamedevForge/Hints/Resources/HintsSettings.asset

<img width="453" height="157" alt="image" src="https://github.com/user-attachments/assets/10eb124e-7675-4fde-9a57-73ae4a80dcc9" />

## Usage example:

```csharp
public class YourCode : MonoBehaviour
{
  public Transform Character;
  public Transform MoveTarget;
  
  void Start()
  {
    Hints.SetTarget(MoveTarget);
  }

  void Update()
  {
    if (Vector3.Distance(Character.position, MoveTarget.position) < 1)
    {
      Hints.Clear();
    }
  }
}
```

