using System;

using Mindscape.LightSpeed;
using Mindscape.LightSpeed.Validation;
using Mindscape.LightSpeed.Linq;

namespace KeepAcconts.Web
{
  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class UserInfo : Entity<int>
  {
    #region Fields
  
    [ValidatePresence]
    [ValidateLength(0, 50)]
    private string _userName;
    [ValidatePresence]
    [ValidateLength(0, 50)]
    private string _loginName;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the UserName entity attribute.</summary>
    public const string UserNameField = "UserName";
    /// <summary>Identifies the LoginName entity attribute.</summary>
    public const string LoginNameField = "LoginName";


    #endregion
    
    #region Properties



    public string UserName
    {
      get { return Get(ref _userName, "UserName"); }
      set { Set(ref _userName, value, "UserName"); }
    }

    public string LoginName
    {
      get { return Get(ref _loginName, "LoginName"); }
      set { Set(ref _loginName, value, "LoginName"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  public partial class KeyTable : Entity<int>
  {
    #region Fields
  
    private int _nextId;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the NextId entity attribute.</summary>
    public const string NextIdField = "NextId";


    #endregion
    
    #region Properties



    public int NextId
    {
      get { return Get(ref _nextId, "NextId"); }
      set { Set(ref _nextId, value, "NextId"); }
    }

    #endregion
  }


  [Serializable]
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  [System.ComponentModel.DataObject]
  [Table("SMS")]
  public partial class Sm : Entity<string>
  {
    #region Fields
  
    private System.Nullable<System.DateTime> _sendTime;
    [ValidateLength(0, 80)]
    private string _name1;

    #endregion
    
    #region Field attribute and view names
    
    /// <summary>Identifies the SendTime entity attribute.</summary>
    public const string SendTimeField = "SendTime";
    /// <summary>Identifies the Name1 entity attribute.</summary>
    public const string Name1Field = "Name1";


    #endregion
    
    #region Properties



    public System.Nullable<System.DateTime> SendTime
    {
      get { return Get(ref _sendTime, "SendTime"); }
      set { Set(ref _sendTime, value, "SendTime"); }
    }

    public string Name1
    {
      get { return Get(ref _name1, "Name1"); }
      set { Set(ref _name1, value, "Name1"); }
    }

    #endregion
  }



  /// <summary>
  /// Provides a strong-typed unit of work for working with the ChargeModal model.
  /// </summary>
  [System.CodeDom.Compiler.GeneratedCode("LightSpeedModelGenerator", "1.0.0.0")]
  public partial class ChargeModalUnitOfWork : Mindscape.LightSpeed.UnitOfWork
  {

    public System.Linq.IQueryable<UserInfo> UserInfos
    {
      get { return this.Query<UserInfo>(); }
    }
    
    public System.Linq.IQueryable<KeyTable> KeyTables
    {
      get { return this.Query<KeyTable>(); }
    }
    
    public System.Linq.IQueryable<Sm> Sms
    {
      get { return this.Query<Sm>(); }
    }
    
  }

}
