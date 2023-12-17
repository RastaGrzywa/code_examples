# Code Examples

Welcome to the "Code Examples" repository! This repository serves as a collection of well-architected Unity projects showcasing various design patterns and systems implemented in C#.
## Purpose

The primary goal of this repository is to demonstrate my coding skills and provide clear examples of how different software engineering concepts can be implemented in Unity using C#. Each example is designed to be modular, easy to understand, and ready for expansion.

## Current Examples
### 1. Command Pattern - _0_Navigation

The Command Pattern example illustrates the implementation of the command design pattern within Unity. It demonstrates how to decouple senders and receivers of requests, allowing for flexible and extensible command execution. It's focused on adding commands and executing them in provided order.

```csharp
public interface ICommand
{
    event Action OnFinished;
    
    void Execute(List<ICommand> commands);
    void Update();
    void Finish();
}

public class CommandInvoker : MonoBehaviour
{
    private List<ICommand> _commands = new();

    private ICommand _currentCommand;

    private void Update()
    {
        if (_commands.Count == 0)
        {
            return;
        }
        
        _commands[0].Update();
    }

    private void ExecuteNextCommand()
    {
        if (_commands.Count == 0)
        {
            return;
        }
        _commands[0].Execute(_commands);
        _commands[0].OnFinished += () =>
        {
            RemoveCommand(0);
            ExecuteNextCommand();
        };
    }
    
    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
        Debug.Log("Command added");
        if (_commands.Count == 1)
        {
            ExecuteNextCommand();
        }
    }

    public void RemoveCommand(ICommand command)
    {
        RemoveCommand(_commands.IndexOf(command));
    }

    private void RemoveCommand(int id)
    {
        _commands.RemoveAt(id);
        Debug.Log("Command removed");
    }

}
```

### 2. Events Channels - _1_SpotEvents

The Events Channels example showcases the usage of an event-driven architecture using Unity's event system. It emphasizes the benefits of loose coupling and simplifying communication between different parts of the application.
Usage

```csharp
public abstract class EventChannel<T> : ScriptableObject
{
    readonly HashSet<EventListener<T>> observers = new();

    public void Invoke(T value)
    {
        foreach (var observer in observers)
        {
            observer.Raise(value);
        }
    }

    public void Register(EventListener<T> observer) => observers.Add(observer);
    public void Deregister(EventListener<T> observer) => observers.Remove(observer);
}

public abstract class EventListener<T> : MonoBehaviour
{
    [SerializeField] private EventChannel<T> eventChannel;
    [SerializeField] private UnityEvent<T> unityEvent;

    private void Awake()
    {
        eventChannel.Register(this);
    }

    private void OnDestroy()
    {
        eventChannel.Deregister(this);
    }

    public void Raise(T value)
    {
        unityEvent?.Invoke(value);   
    }
}
```



### 3. Object pooling - _2_PullMyObjects

The Object Pooling example illustrates the efficient management of game objects by reusing instances rather than instantiating and destroying them. This approach is crucial for optimizing performance in scenarios where frequent instantiation and destruction are involved.
You can check both standard and object pooling approach.

Usage

```csharp
public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private int poolSize = 10;

    private readonly Queue<GameObject> _bulletPool = new Queue<GameObject>();

    private void Awake()
    {
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
        for (var i = 0; i < poolSize; i++)
        {
            var bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            _bulletPool.Enqueue(bullet);
        }
    }

    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {
        if (_bulletPool.Count == 0)
        {
            ExpandPool();
        }

        var bullet = _bulletPool.Dequeue();
        bullet.transform.position = position;
        bullet.transform.rotation = rotation;
        bullet.SetActive(true);

        return bullet;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }

    private void ExpandPool()
    {
        var bullet = Instantiate(bulletPrefab);
        bullet.SetActive(false);
        _bulletPool.Enqueue(bullet);
    }
}

public class OPBulletSpawner : MonoBehaviour
{
    ...

    private void SpawnBullet()
    {
        GameObject bullet = Scripts.ObjectPool.ObjectPool.Instance.GetBullet(spawnTransform.position, Quaternion.identity);
        bullet.transform.up = spawnTransform.forward;
        bullet.GetComponent<Rigidbody>().AddForce(spawnTransform.forward * 50, ForceMode.Impulse);
    }
}

public class OPBullet : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke(nameof(DisableBullet), 10f);
        
    }
    
    private void DisableBullet()
    {
        Scripts.ObjectPool.ObjectPool.Instance.ReturnBullet(gameObject);
    }
}
```


## How to Use

Each example is contained within its own directory. To integrate an example into your Unity project, follow these steps:

    Clone the repository: git clone https://github.com/your-username/Code-Examples.git
    Copy the desired example directory into your Unity project.
    Or
    Open provided Unity project and test scene of each example. 

## Contributing

If you find a bug, have a suggestion, or want to contribute an additional example, please feel free to open an issue or create a pull request. Your contributions are highly valued!
## License

This project is licensed under the MIT License.
