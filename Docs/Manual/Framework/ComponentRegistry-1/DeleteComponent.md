# ComponentRegistry&lt;T&gt;.DeleteComponent method (1 of 2)

Delete a given componentn from base component by given type

```csharp
public void DeleteComponent(Type componentType)
```

| parameter | description |
| --- | --- |
| componentType | Type of component which have to be deleted |

## See Also

* class [ComponentRegistry&lt;T&gt;](../ComponentRegistry-1.md)
* namespace [Framework](../../Framework.md)

---

# ComponentRegistry&lt;T&gt;.DeleteComponent&lt;T2&gt; method (2 of 2)

Delete a given componentn from base component

```csharp
public void DeleteComponent<T2>()
    where T2 : Node, IChildComponent<T>
```

| parameter | description |
| --- | --- |
| T2 |  |

## See Also

* interface [IChildComponent&lt;T&gt;](../IChildComponent-1.md)
* class [ComponentRegistry&lt;T&gt;](../ComponentRegistry-1.md)
* namespace [Framework](../../Framework.md)

<!-- DO NOT EDIT: generated by xmldocmd for Framework.dll -->