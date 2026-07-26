
class NewInteractiveObjectEvent
{
    public ObjectData Data { get; private set; }
    public NewInteractiveObjectEvent(ObjectData Data)
    {
        this.Data = Data;
    }

}

