//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: info.proto
namespace message
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GCInfoPrompt")]
  public partial class GCInfoPrompt : global::ProtoBuf.IExtensible
  {
    public GCInfoPrompt() {}
    
    private int _code;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"code", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int code
    {
      get { return _code; }
      set { _code = value; }
    }
    private string _contents;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"contents", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string contents
    {
      get { return _contents; }
      set { _contents = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GCIdlePrompt")]
  public partial class GCIdlePrompt : global::ProtoBuf.IExtensible
  {
    public GCIdlePrompt() {}
    
    private string _contents;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"contents", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string contents
    {
      get { return _contents; }
      set { _contents = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}