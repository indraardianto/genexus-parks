using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Repair.Kind" )]
   [XmlType(TypeName =  "Repair.Kind" , Namespace = "Parksz" )]
   [Serializable]
   public class SdtRepair_Kind : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtRepair_Kind( )
      {
      }

      public SdtRepair_Kind( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RepairKindId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Kind");
         metadata.Set("BT", "RepairRepairTransaction");
         metadata.Set("PK", "[ \"RepairKindId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"RepairId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Repairkindid_Z");
         state.Add("gxTpr_Repairkindname_Z");
         state.Add("gxTpr_Repairkindremarks_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRepair_Kind sdt;
         sdt = (SdtRepair_Kind)(source);
         gxTv_SdtRepair_Kind_Repairkindid = sdt.gxTv_SdtRepair_Kind_Repairkindid ;
         gxTv_SdtRepair_Kind_Repairkindname = sdt.gxTv_SdtRepair_Kind_Repairkindname ;
         gxTv_SdtRepair_Kind_Repairkindremarks = sdt.gxTv_SdtRepair_Kind_Repairkindremarks ;
         gxTv_SdtRepair_Kind_Mode = sdt.gxTv_SdtRepair_Kind_Mode ;
         gxTv_SdtRepair_Kind_Modified = sdt.gxTv_SdtRepair_Kind_Modified ;
         gxTv_SdtRepair_Kind_Initialized = sdt.gxTv_SdtRepair_Kind_Initialized ;
         gxTv_SdtRepair_Kind_Repairkindid_Z = sdt.gxTv_SdtRepair_Kind_Repairkindid_Z ;
         gxTv_SdtRepair_Kind_Repairkindname_Z = sdt.gxTv_SdtRepair_Kind_Repairkindname_Z ;
         gxTv_SdtRepair_Kind_Repairkindremarks_Z = sdt.gxTv_SdtRepair_Kind_Repairkindremarks_Z ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("RepairKindId", gxTv_SdtRepair_Kind_Repairkindid, false, includeNonInitialized);
         AddObjectProperty("RepairKindName", gxTv_SdtRepair_Kind_Repairkindname, false, includeNonInitialized);
         AddObjectProperty("RepairKindRemarks", gxTv_SdtRepair_Kind_Repairkindremarks, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRepair_Kind_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtRepair_Kind_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRepair_Kind_Initialized, false, includeNonInitialized);
            AddObjectProperty("RepairKindId_Z", gxTv_SdtRepair_Kind_Repairkindid_Z, false, includeNonInitialized);
            AddObjectProperty("RepairKindName_Z", gxTv_SdtRepair_Kind_Repairkindname_Z, false, includeNonInitialized);
            AddObjectProperty("RepairKindRemarks_Z", gxTv_SdtRepair_Kind_Repairkindremarks_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRepair_Kind sdt )
      {
         if ( sdt.IsDirty("RepairKindId") )
         {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindid = sdt.gxTv_SdtRepair_Kind_Repairkindid ;
         }
         if ( sdt.IsDirty("RepairKindName") )
         {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindname = sdt.gxTv_SdtRepair_Kind_Repairkindname ;
         }
         if ( sdt.IsDirty("RepairKindRemarks") )
         {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindremarks = sdt.gxTv_SdtRepair_Kind_Repairkindremarks ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RepairKindId" )]
      [  XmlElement( ElementName = "RepairKindId"   )]
      public short gxTpr_Repairkindid
      {
         get {
            return gxTv_SdtRepair_Kind_Repairkindid ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindid = value;
            gxTv_SdtRepair_Kind_Modified = 1;
            SetDirty("Repairkindid");
         }

      }

      [  SoapElement( ElementName = "RepairKindName" )]
      [  XmlElement( ElementName = "RepairKindName"   )]
      public string gxTpr_Repairkindname
      {
         get {
            return gxTv_SdtRepair_Kind_Repairkindname ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindname = value;
            gxTv_SdtRepair_Kind_Modified = 1;
            SetDirty("Repairkindname");
         }

      }

      [  SoapElement( ElementName = "RepairKindRemarks" )]
      [  XmlElement( ElementName = "RepairKindRemarks"   )]
      public string gxTpr_Repairkindremarks
      {
         get {
            return gxTv_SdtRepair_Kind_Repairkindremarks ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindremarks = value;
            gxTv_SdtRepair_Kind_Modified = 1;
            SetDirty("Repairkindremarks");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRepair_Kind_Mode ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRepair_Kind_Mode_SetNull( )
      {
         gxTv_SdtRepair_Kind_Mode = "";
         return  ;
      }

      public bool gxTv_SdtRepair_Kind_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtRepair_Kind_Modified ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtRepair_Kind_Modified_SetNull( )
      {
         gxTv_SdtRepair_Kind_Modified = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Kind_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRepair_Kind_Initialized ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Initialized = value;
            gxTv_SdtRepair_Kind_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRepair_Kind_Initialized_SetNull( )
      {
         gxTv_SdtRepair_Kind_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Kind_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairKindId_Z" )]
      [  XmlElement( ElementName = "RepairKindId_Z"   )]
      public short gxTpr_Repairkindid_Z
      {
         get {
            return gxTv_SdtRepair_Kind_Repairkindid_Z ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindid_Z = value;
            gxTv_SdtRepair_Kind_Modified = 1;
            SetDirty("Repairkindid_Z");
         }

      }

      public void gxTv_SdtRepair_Kind_Repairkindid_Z_SetNull( )
      {
         gxTv_SdtRepair_Kind_Repairkindid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Kind_Repairkindid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairKindName_Z" )]
      [  XmlElement( ElementName = "RepairKindName_Z"   )]
      public string gxTpr_Repairkindname_Z
      {
         get {
            return gxTv_SdtRepair_Kind_Repairkindname_Z ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindname_Z = value;
            gxTv_SdtRepair_Kind_Modified = 1;
            SetDirty("Repairkindname_Z");
         }

      }

      public void gxTv_SdtRepair_Kind_Repairkindname_Z_SetNull( )
      {
         gxTv_SdtRepair_Kind_Repairkindname_Z = "";
         return  ;
      }

      public bool gxTv_SdtRepair_Kind_Repairkindname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairKindRemarks_Z" )]
      [  XmlElement( ElementName = "RepairKindRemarks_Z"   )]
      public string gxTpr_Repairkindremarks_Z
      {
         get {
            return gxTv_SdtRepair_Kind_Repairkindremarks_Z ;
         }

         set {
            gxTv_SdtRepair_Kind_N = 0;
            gxTv_SdtRepair_Kind_Repairkindremarks_Z = value;
            gxTv_SdtRepair_Kind_Modified = 1;
            SetDirty("Repairkindremarks_Z");
         }

      }

      public void gxTv_SdtRepair_Kind_Repairkindremarks_Z_SetNull( )
      {
         gxTv_SdtRepair_Kind_Repairkindremarks_Z = "";
         return  ;
      }

      public bool gxTv_SdtRepair_Kind_Repairkindremarks_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtRepair_Kind_N = 1;
         gxTv_SdtRepair_Kind_Repairkindname = "";
         gxTv_SdtRepair_Kind_Repairkindremarks = "";
         gxTv_SdtRepair_Kind_Mode = "";
         gxTv_SdtRepair_Kind_Repairkindname_Z = "";
         gxTv_SdtRepair_Kind_Repairkindremarks_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtRepair_Kind_N ;
      }

      private short gxTv_SdtRepair_Kind_Repairkindid ;
      private short gxTv_SdtRepair_Kind_N ;
      private short gxTv_SdtRepair_Kind_Modified ;
      private short gxTv_SdtRepair_Kind_Initialized ;
      private short gxTv_SdtRepair_Kind_Repairkindid_Z ;
      private string gxTv_SdtRepair_Kind_Repairkindname ;
      private string gxTv_SdtRepair_Kind_Repairkindremarks ;
      private string gxTv_SdtRepair_Kind_Mode ;
      private string gxTv_SdtRepair_Kind_Repairkindname_Z ;
      private string gxTv_SdtRepair_Kind_Repairkindremarks_Z ;
   }

   [DataContract(Name = @"Repair.Kind", Namespace = "Parksz")]
   public class SdtRepair_Kind_RESTInterface : GxGenericCollectionItem<SdtRepair_Kind>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRepair_Kind_RESTInterface( ) : base()
      {
      }

      public SdtRepair_Kind_RESTInterface( SdtRepair_Kind psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RepairKindId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Repairkindid
      {
         get {
            return sdt.gxTpr_Repairkindid ;
         }

         set {
            sdt.gxTpr_Repairkindid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RepairKindName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Repairkindname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Repairkindname) ;
         }

         set {
            sdt.gxTpr_Repairkindname = value;
         }

      }

      [DataMember( Name = "RepairKindRemarks" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Repairkindremarks
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Repairkindremarks) ;
         }

         set {
            sdt.gxTpr_Repairkindremarks = value;
         }

      }

      public SdtRepair_Kind sdt
      {
         get {
            return (SdtRepair_Kind)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtRepair_Kind() ;
         }
      }

   }

   [DataContract(Name = @"Repair.Kind", Namespace = "Parksz")]
   public class SdtRepair_Kind_RESTLInterface : GxGenericCollectionItem<SdtRepair_Kind>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRepair_Kind_RESTLInterface( ) : base()
      {
      }

      public SdtRepair_Kind_RESTLInterface( SdtRepair_Kind psdt ) : base(psdt)
      {
      }

      public SdtRepair_Kind sdt
      {
         get {
            return (SdtRepair_Kind)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtRepair_Kind() ;
         }
      }

   }

}
