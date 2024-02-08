# DefaultLibrary
Abstract Class Library
## DefaultResponse
Default Response is an abstract class for method responses. Contains the response status, a list of errors, and the HasErrors attribute.
### Example:
```
using DefaultLibrary.Response;
using DefaultLibrary.Shared;
public class SomeClass
{
    public ConcreteResponse SomeMethod()
    {
        var response = new ConcreteResponse();
        try
        {
            response.Status = Status.Ok;
            response.SomeProperty = "SomeValue";
        }
        catch (Exception e)
        {
            response.AddError(e.Message, null, this.SomeMethod().ToString(), e.StackTrace);
        }
        return response;
    }
}
public class ConcreteResponse : DefaultResponse
{
    public string SomeProperty { get; set; }
}
```
