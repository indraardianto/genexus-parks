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
   [XmlRoot(ElementName = "Repair" )]
   [XmlType(TypeName =  "Repair" , Namespace = "Parksz" )]
   [Serializable]
   public class SdtRepair : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRepair( )
      {
      }

      public SdtRepair( IGxContext context )
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

      public void Load( short AV22RepairId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV22RepairId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RepairId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Repair");
         metadata.Set("BT", "Repair");
         metadata.Set("PK", "[ \"RepairId\" ]");
         metadata.Set("PKAssigned", "[ \"RepairId\" ]");
         metadata.Set("Levels", "[ \"Kind\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"GameId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TechnicianId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TechnicianId\" ],\"FKMap\":[ \"RepairAlternateTechnicianId-TechnicianId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Repairid_Z");
         state.Add("gxTpr_Repairdatefrom_Z_Nullable");
         state.Add("gxTpr_Repairdaysquantity_Z");
         state.Add("gxTpr_Repairdateto_Z_Nullable");
         state.Add("gxTpr_Gameid_Z");
         state.Add("gxTpr_Gamename_Z");
         state.Add("gxTpr_Repaircost_Z");
         state.Add("gxTpr_Technicianid_Z");
         state.Add("gxTpr_Technicianname_Z");
         state.Add("gxTpr_Repairalternatetechnicianid_Z");
         state.Add("gxTpr_Repairalternatetechnicianname_Z");
         state.Add("gxTpr_Repairdiscountpercentage_Z");
         state.Add("gxTpr_Repairfinalcost_Z");
         state.Add("gxTpr_Repairproblems_Z");
         state.Add("gxTpr_Repairproblems_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRepair sdt;
         sdt = (SdtRepair)(source);
         gxTv_SdtRepair_Repairid = sdt.gxTv_SdtRepair_Repairid ;
         gxTv_SdtRepair_Repairdatefrom = sdt.gxTv_SdtRepair_Repairdatefrom ;
         gxTv_SdtRepair_Repairdaysquantity = sdt.gxTv_SdtRepair_Repairdaysquantity ;
         gxTv_SdtRepair_Repairdateto = sdt.gxTv_SdtRepair_Repairdateto ;
         gxTv_SdtRepair_Gameid = sdt.gxTv_SdtRepair_Gameid ;
         gxTv_SdtRepair_Gamename = sdt.gxTv_SdtRepair_Gamename ;
         gxTv_SdtRepair_Repaircost = sdt.gxTv_SdtRepair_Repaircost ;
         gxTv_SdtRepair_Technicianid = sdt.gxTv_SdtRepair_Technicianid ;
         gxTv_SdtRepair_Technicianname = sdt.gxTv_SdtRepair_Technicianname ;
         gxTv_SdtRepair_Repairalternatetechnicianid = sdt.gxTv_SdtRepair_Repairalternatetechnicianid ;
         gxTv_SdtRepair_Repairalternatetechnicianname = sdt.gxTv_SdtRepair_Repairalternatetechnicianname ;
         gxTv_SdtRepair_Repairdiscountpercentage = sdt.gxTv_SdtRepair_Repairdiscountpercentage ;
         gxTv_SdtRepair_Repairfinalcost = sdt.gxTv_SdtRepair_Repairfinalcost ;
         gxTv_SdtRepair_Repairproblems = sdt.gxTv_SdtRepair_Repairproblems ;
         gxTv_SdtRepair_Kind = sdt.gxTv_SdtRepair_Kind ;
         gxTv_SdtRepair_Mode = sdt.gxTv_SdtRepair_Mode ;
         gxTv_SdtRepair_Initialized = sdt.gxTv_SdtRepair_Initialized ;
         gxTv_SdtRepair_Repairid_Z = sdt.gxTv_SdtRepair_Repairid_Z ;
         gxTv_SdtRepair_Repairdatefrom_Z = sdt.gxTv_SdtRepair_Repairdatefrom_Z ;
         gxTv_SdtRepair_Repairdaysquantity_Z = sdt.gxTv_SdtRepair_Repairdaysquantity_Z ;
         gxTv_SdtRepair_Repairdateto_Z = sdt.gxTv_SdtRepair_Repairdateto_Z ;
         gxTv_SdtRepair_Gameid_Z = sdt.gxTv_SdtRepair_Gameid_Z ;
         gxTv_SdtRepair_Gamename_Z = sdt.gxTv_SdtRepair_Gamename_Z ;
         gxTv_SdtRepair_Repaircost_Z = sdt.gxTv_SdtRepair_Repaircost_Z ;
         gxTv_SdtRepair_Technicianid_Z = sdt.gxTv_SdtRepair_Technicianid_Z ;
         gxTv_SdtRepair_Technicianname_Z = sdt.gxTv_SdtRepair_Technicianname_Z ;
         gxTv_SdtRepair_Repairalternatetechnicianid_Z = sdt.gxTv_SdtRepair_Repairalternatetechnicianid_Z ;
         gxTv_SdtRepair_Repairalternatetechnicianname_Z = sdt.gxTv_SdtRepair_Repairalternatetechnicianname_Z ;
         gxTv_SdtRepair_Repairdiscountpercentage_Z = sdt.gxTv_SdtRepair_Repairdiscountpercentage_Z ;
         gxTv_SdtRepair_Repairfinalcost_Z = sdt.gxTv_SdtRepair_Repairfinalcost_Z ;
         gxTv_SdtRepair_Repairproblems_Z = sdt.gxTv_SdtRepair_Repairproblems_Z ;
         gxTv_SdtRepair_Repairproblems_N = sdt.gxTv_SdtRepair_Repairproblems_N ;
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
         AddObjectProperty("RepairId", gxTv_SdtRepair_Repairid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtRepair_Repairdatefrom)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtRepair_Repairdatefrom)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtRepair_Repairdatefrom)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("RepairDateFrom", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("RepairDaysQuantity", gxTv_SdtRepair_Repairdaysquantity, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtRepair_Repairdateto)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtRepair_Repairdateto)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtRepair_Repairdateto)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("RepairDateTo", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("GameId", gxTv_SdtRepair_Gameid, false, includeNonInitialized);
         AddObjectProperty("GameName", gxTv_SdtRepair_Gamename, false, includeNonInitialized);
         AddObjectProperty("RepairCost", gxTv_SdtRepair_Repaircost, false, includeNonInitialized);
         AddObjectProperty("TechnicianId", gxTv_SdtRepair_Technicianid, false, includeNonInitialized);
         AddObjectProperty("TechnicianName", gxTv_SdtRepair_Technicianname, false, includeNonInitialized);
         AddObjectProperty("RepairAlternateTechnicianId", gxTv_SdtRepair_Repairalternatetechnicianid, false, includeNonInitialized);
         AddObjectProperty("RepairAlternateTechnicianName", gxTv_SdtRepair_Repairalternatetechnicianname, false, includeNonInitialized);
         AddObjectProperty("RepairDiscountPercentage", gxTv_SdtRepair_Repairdiscountpercentage, false, includeNonInitialized);
         AddObjectProperty("RepairFinalCost", gxTv_SdtRepair_Repairfinalcost, false, includeNonInitialized);
         AddObjectProperty("RepairProblems", gxTv_SdtRepair_Repairproblems, false, includeNonInitialized);
         AddObjectProperty("RepairProblems_N", gxTv_SdtRepair_Repairproblems_N, false, includeNonInitialized);
         if ( gxTv_SdtRepair_Kind != null )
         {
            AddObjectProperty("Kind", gxTv_SdtRepair_Kind, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtRepair_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRepair_Initialized, false, includeNonInitialized);
            AddObjectProperty("RepairId_Z", gxTv_SdtRepair_Repairid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtRepair_Repairdatefrom_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtRepair_Repairdatefrom_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtRepair_Repairdatefrom_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("RepairDateFrom_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("RepairDaysQuantity_Z", gxTv_SdtRepair_Repairdaysquantity_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtRepair_Repairdateto_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtRepair_Repairdateto_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtRepair_Repairdateto_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("RepairDateTo_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("GameId_Z", gxTv_SdtRepair_Gameid_Z, false, includeNonInitialized);
            AddObjectProperty("GameName_Z", gxTv_SdtRepair_Gamename_Z, false, includeNonInitialized);
            AddObjectProperty("RepairCost_Z", gxTv_SdtRepair_Repaircost_Z, false, includeNonInitialized);
            AddObjectProperty("TechnicianId_Z", gxTv_SdtRepair_Technicianid_Z, false, includeNonInitialized);
            AddObjectProperty("TechnicianName_Z", gxTv_SdtRepair_Technicianname_Z, false, includeNonInitialized);
            AddObjectProperty("RepairAlternateTechnicianId_Z", gxTv_SdtRepair_Repairalternatetechnicianid_Z, false, includeNonInitialized);
            AddObjectProperty("RepairAlternateTechnicianName_Z", gxTv_SdtRepair_Repairalternatetechnicianname_Z, false, includeNonInitialized);
            AddObjectProperty("RepairDiscountPercentage_Z", gxTv_SdtRepair_Repairdiscountpercentage_Z, false, includeNonInitialized);
            AddObjectProperty("RepairFinalCost_Z", gxTv_SdtRepair_Repairfinalcost_Z, false, includeNonInitialized);
            AddObjectProperty("RepairProblems_Z", gxTv_SdtRepair_Repairproblems_Z, false, includeNonInitialized);
            AddObjectProperty("RepairProblems_N", gxTv_SdtRepair_Repairproblems_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRepair sdt )
      {
         if ( sdt.IsDirty("RepairId") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairid = sdt.gxTv_SdtRepair_Repairid ;
         }
         if ( sdt.IsDirty("RepairDateFrom") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdatefrom = sdt.gxTv_SdtRepair_Repairdatefrom ;
         }
         if ( sdt.IsDirty("RepairDaysQuantity") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdaysquantity = sdt.gxTv_SdtRepair_Repairdaysquantity ;
         }
         if ( sdt.IsDirty("RepairDateTo") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdateto = sdt.gxTv_SdtRepair_Repairdateto ;
         }
         if ( sdt.IsDirty("GameId") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Gameid = sdt.gxTv_SdtRepair_Gameid ;
         }
         if ( sdt.IsDirty("GameName") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Gamename = sdt.gxTv_SdtRepair_Gamename ;
         }
         if ( sdt.IsDirty("RepairCost") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repaircost = sdt.gxTv_SdtRepair_Repaircost ;
         }
         if ( sdt.IsDirty("TechnicianId") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Technicianid = sdt.gxTv_SdtRepair_Technicianid ;
         }
         if ( sdt.IsDirty("TechnicianName") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Technicianname = sdt.gxTv_SdtRepair_Technicianname ;
         }
         if ( sdt.IsDirty("RepairAlternateTechnicianId") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairalternatetechnicianid = sdt.gxTv_SdtRepair_Repairalternatetechnicianid ;
         }
         if ( sdt.IsDirty("RepairAlternateTechnicianName") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairalternatetechnicianname = sdt.gxTv_SdtRepair_Repairalternatetechnicianname ;
         }
         if ( sdt.IsDirty("RepairDiscountPercentage") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdiscountpercentage = sdt.gxTv_SdtRepair_Repairdiscountpercentage ;
         }
         if ( sdt.IsDirty("RepairFinalCost") )
         {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairfinalcost = sdt.gxTv_SdtRepair_Repairfinalcost ;
         }
         if ( sdt.IsDirty("RepairProblems") )
         {
            gxTv_SdtRepair_Repairproblems_N = 0;
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairproblems = sdt.gxTv_SdtRepair_Repairproblems ;
         }
         if ( gxTv_SdtRepair_Kind != null )
         {
            GXBCLevelCollection<SdtRepair_Kind> newCollectionKind = sdt.gxTpr_Kind;
            SdtRepair_Kind currItemKind;
            SdtRepair_Kind newItemKind;
            short idx = 1;
            while ( idx <= newCollectionKind.Count )
            {
               newItemKind = ((SdtRepair_Kind)newCollectionKind.Item(idx));
               currItemKind = gxTv_SdtRepair_Kind.GetByKey(newItemKind.gxTpr_Repairkindid);
               if ( StringUtil.StrCmp(currItemKind.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemKind.UpdateDirties(newItemKind);
                  if ( StringUtil.StrCmp(newItemKind.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemKind.gxTpr_Mode = "DLT";
                  }
                  currItemKind.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtRepair_Kind.Add(newItemKind, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "RepairId" )]
      [  XmlElement( ElementName = "RepairId"   )]
      public short gxTpr_Repairid
      {
         get {
            return gxTv_SdtRepair_Repairid ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            if ( gxTv_SdtRepair_Repairid != value )
            {
               gxTv_SdtRepair_Mode = "INS";
               this.gxTv_SdtRepair_Repairid_Z_SetNull( );
               this.gxTv_SdtRepair_Repairdatefrom_Z_SetNull( );
               this.gxTv_SdtRepair_Repairdaysquantity_Z_SetNull( );
               this.gxTv_SdtRepair_Repairdateto_Z_SetNull( );
               this.gxTv_SdtRepair_Gameid_Z_SetNull( );
               this.gxTv_SdtRepair_Gamename_Z_SetNull( );
               this.gxTv_SdtRepair_Repaircost_Z_SetNull( );
               this.gxTv_SdtRepair_Technicianid_Z_SetNull( );
               this.gxTv_SdtRepair_Technicianname_Z_SetNull( );
               this.gxTv_SdtRepair_Repairalternatetechnicianid_Z_SetNull( );
               this.gxTv_SdtRepair_Repairalternatetechnicianname_Z_SetNull( );
               this.gxTv_SdtRepair_Repairdiscountpercentage_Z_SetNull( );
               this.gxTv_SdtRepair_Repairfinalcost_Z_SetNull( );
               this.gxTv_SdtRepair_Repairproblems_Z_SetNull( );
               if ( gxTv_SdtRepair_Kind != null )
               {
                  GXBCLevelCollection<SdtRepair_Kind> collectionKind = gxTv_SdtRepair_Kind;
                  SdtRepair_Kind currItemKind;
                  short idx = 1;
                  while ( idx <= collectionKind.Count )
                  {
                     currItemKind = ((SdtRepair_Kind)collectionKind.Item(idx));
                     currItemKind.gxTpr_Mode = "INS";
                     currItemKind.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtRepair_Repairid = value;
            SetDirty("Repairid");
         }

      }

      [  SoapElement( ElementName = "RepairDateFrom" )]
      [  XmlElement( ElementName = "RepairDateFrom"  , IsNullable=true )]
      public string gxTpr_Repairdatefrom_Nullable
      {
         get {
            if ( gxTv_SdtRepair_Repairdatefrom == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtRepair_Repairdatefrom).value ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtRepair_Repairdatefrom = DateTime.MinValue;
            else
               gxTv_SdtRepair_Repairdatefrom = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Repairdatefrom
      {
         get {
            return gxTv_SdtRepair_Repairdatefrom ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdatefrom = value;
            SetDirty("Repairdatefrom");
         }

      }

      [  SoapElement( ElementName = "RepairDaysQuantity" )]
      [  XmlElement( ElementName = "RepairDaysQuantity"   )]
      public short gxTpr_Repairdaysquantity
      {
         get {
            return gxTv_SdtRepair_Repairdaysquantity ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdaysquantity = value;
            SetDirty("Repairdaysquantity");
         }

      }

      [  SoapElement( ElementName = "RepairDateTo" )]
      [  XmlElement( ElementName = "RepairDateTo"  , IsNullable=true )]
      public string gxTpr_Repairdateto_Nullable
      {
         get {
            if ( gxTv_SdtRepair_Repairdateto == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtRepair_Repairdateto).value ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtRepair_Repairdateto = DateTime.MinValue;
            else
               gxTv_SdtRepair_Repairdateto = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Repairdateto
      {
         get {
            return gxTv_SdtRepair_Repairdateto ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdateto = value;
            SetDirty("Repairdateto");
         }

      }

      public void gxTv_SdtRepair_Repairdateto_SetNull( )
      {
         gxTv_SdtRepair_Repairdateto = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtRepair_Repairdateto_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GameId" )]
      [  XmlElement( ElementName = "GameId"   )]
      public short gxTpr_Gameid
      {
         get {
            return gxTv_SdtRepair_Gameid ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Gameid = value;
            SetDirty("Gameid");
         }

      }

      [  SoapElement( ElementName = "GameName" )]
      [  XmlElement( ElementName = "GameName"   )]
      public string gxTpr_Gamename
      {
         get {
            return gxTv_SdtRepair_Gamename ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Gamename = value;
            SetDirty("Gamename");
         }

      }

      [  SoapElement( ElementName = "RepairCost" )]
      [  XmlElement( ElementName = "RepairCost"   )]
      public short gxTpr_Repaircost
      {
         get {
            return gxTv_SdtRepair_Repaircost ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repaircost = value;
            SetDirty("Repaircost");
         }

      }

      [  SoapElement( ElementName = "TechnicianId" )]
      [  XmlElement( ElementName = "TechnicianId"   )]
      public short gxTpr_Technicianid
      {
         get {
            return gxTv_SdtRepair_Technicianid ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Technicianid = value;
            SetDirty("Technicianid");
         }

      }

      [  SoapElement( ElementName = "TechnicianName" )]
      [  XmlElement( ElementName = "TechnicianName"   )]
      public string gxTpr_Technicianname
      {
         get {
            return gxTv_SdtRepair_Technicianname ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Technicianname = value;
            SetDirty("Technicianname");
         }

      }

      [  SoapElement( ElementName = "RepairAlternateTechnicianId" )]
      [  XmlElement( ElementName = "RepairAlternateTechnicianId"   )]
      public short gxTpr_Repairalternatetechnicianid
      {
         get {
            return gxTv_SdtRepair_Repairalternatetechnicianid ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairalternatetechnicianid = value;
            SetDirty("Repairalternatetechnicianid");
         }

      }

      [  SoapElement( ElementName = "RepairAlternateTechnicianName" )]
      [  XmlElement( ElementName = "RepairAlternateTechnicianName"   )]
      public string gxTpr_Repairalternatetechnicianname
      {
         get {
            return gxTv_SdtRepair_Repairalternatetechnicianname ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairalternatetechnicianname = value;
            SetDirty("Repairalternatetechnicianname");
         }

      }

      [  SoapElement( ElementName = "RepairDiscountPercentage" )]
      [  XmlElement( ElementName = "RepairDiscountPercentage"   )]
      public short gxTpr_Repairdiscountpercentage
      {
         get {
            return gxTv_SdtRepair_Repairdiscountpercentage ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdiscountpercentage = value;
            SetDirty("Repairdiscountpercentage");
         }

      }

      [  SoapElement( ElementName = "RepairFinalCost" )]
      [  XmlElement( ElementName = "RepairFinalCost"   )]
      public short gxTpr_Repairfinalcost
      {
         get {
            return gxTv_SdtRepair_Repairfinalcost ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairfinalcost = value;
            SetDirty("Repairfinalcost");
         }

      }

      public void gxTv_SdtRepair_Repairfinalcost_SetNull( )
      {
         gxTv_SdtRepair_Repairfinalcost = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairfinalcost_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairProblems" )]
      [  XmlElement( ElementName = "RepairProblems"   )]
      public short gxTpr_Repairproblems
      {
         get {
            return gxTv_SdtRepair_Repairproblems ;
         }

         set {
            gxTv_SdtRepair_Repairproblems_N = 0;
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairproblems = value;
            SetDirty("Repairproblems");
         }

      }

      public void gxTv_SdtRepair_Repairproblems_SetNull( )
      {
         gxTv_SdtRepair_Repairproblems_N = 1;
         gxTv_SdtRepair_Repairproblems = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairproblems_IsNull( )
      {
         return (gxTv_SdtRepair_Repairproblems_N==1) ;
      }

      [  SoapElement( ElementName = "Kind" )]
      [  XmlArray( ElementName = "Kind"  )]
      [  XmlArrayItemAttribute( ElementName= "Repair.Kind"  , IsNullable=false)]
      public GXBCLevelCollection<SdtRepair_Kind> gxTpr_Kind_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtRepair_Kind == null )
            {
               gxTv_SdtRepair_Kind = new GXBCLevelCollection<SdtRepair_Kind>( context, "Repair.Kind", "Parksz");
            }
            return gxTv_SdtRepair_Kind ;
         }

         set {
            if ( gxTv_SdtRepair_Kind == null )
            {
               gxTv_SdtRepair_Kind = new GXBCLevelCollection<SdtRepair_Kind>( context, "Repair.Kind", "Parksz");
            }
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Kind = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtRepair_Kind> gxTpr_Kind
      {
         get {
            if ( gxTv_SdtRepair_Kind == null )
            {
               gxTv_SdtRepair_Kind = new GXBCLevelCollection<SdtRepair_Kind>( context, "Repair.Kind", "Parksz");
            }
            gxTv_SdtRepair_N = 0;
            return gxTv_SdtRepair_Kind ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Kind = value;
            SetDirty("Kind");
         }

      }

      public void gxTv_SdtRepair_Kind_SetNull( )
      {
         gxTv_SdtRepair_Kind = null;
         return  ;
      }

      public bool gxTv_SdtRepair_Kind_IsNull( )
      {
         if ( gxTv_SdtRepair_Kind == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRepair_Mode ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRepair_Mode_SetNull( )
      {
         gxTv_SdtRepair_Mode = "";
         return  ;
      }

      public bool gxTv_SdtRepair_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRepair_Initialized ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRepair_Initialized_SetNull( )
      {
         gxTv_SdtRepair_Initialized = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairId_Z" )]
      [  XmlElement( ElementName = "RepairId_Z"   )]
      public short gxTpr_Repairid_Z
      {
         get {
            return gxTv_SdtRepair_Repairid_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairid_Z = value;
            SetDirty("Repairid_Z");
         }

      }

      public void gxTv_SdtRepair_Repairid_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairDateFrom_Z" )]
      [  XmlElement( ElementName = "RepairDateFrom_Z"  , IsNullable=true )]
      public string gxTpr_Repairdatefrom_Z_Nullable
      {
         get {
            if ( gxTv_SdtRepair_Repairdatefrom_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtRepair_Repairdatefrom_Z).value ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtRepair_Repairdatefrom_Z = DateTime.MinValue;
            else
               gxTv_SdtRepair_Repairdatefrom_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Repairdatefrom_Z
      {
         get {
            return gxTv_SdtRepair_Repairdatefrom_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdatefrom_Z = value;
            SetDirty("Repairdatefrom_Z");
         }

      }

      public void gxTv_SdtRepair_Repairdatefrom_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairdatefrom_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtRepair_Repairdatefrom_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairDaysQuantity_Z" )]
      [  XmlElement( ElementName = "RepairDaysQuantity_Z"   )]
      public short gxTpr_Repairdaysquantity_Z
      {
         get {
            return gxTv_SdtRepair_Repairdaysquantity_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdaysquantity_Z = value;
            SetDirty("Repairdaysquantity_Z");
         }

      }

      public void gxTv_SdtRepair_Repairdaysquantity_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairdaysquantity_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairdaysquantity_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairDateTo_Z" )]
      [  XmlElement( ElementName = "RepairDateTo_Z"  , IsNullable=true )]
      public string gxTpr_Repairdateto_Z_Nullable
      {
         get {
            if ( gxTv_SdtRepair_Repairdateto_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtRepair_Repairdateto_Z).value ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtRepair_Repairdateto_Z = DateTime.MinValue;
            else
               gxTv_SdtRepair_Repairdateto_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Repairdateto_Z
      {
         get {
            return gxTv_SdtRepair_Repairdateto_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdateto_Z = value;
            SetDirty("Repairdateto_Z");
         }

      }

      public void gxTv_SdtRepair_Repairdateto_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairdateto_Z = (DateTime)(DateTime.MinValue);
         return  ;
      }

      public bool gxTv_SdtRepair_Repairdateto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GameId_Z" )]
      [  XmlElement( ElementName = "GameId_Z"   )]
      public short gxTpr_Gameid_Z
      {
         get {
            return gxTv_SdtRepair_Gameid_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Gameid_Z = value;
            SetDirty("Gameid_Z");
         }

      }

      public void gxTv_SdtRepair_Gameid_Z_SetNull( )
      {
         gxTv_SdtRepair_Gameid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Gameid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "GameName_Z" )]
      [  XmlElement( ElementName = "GameName_Z"   )]
      public string gxTpr_Gamename_Z
      {
         get {
            return gxTv_SdtRepair_Gamename_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Gamename_Z = value;
            SetDirty("Gamename_Z");
         }

      }

      public void gxTv_SdtRepair_Gamename_Z_SetNull( )
      {
         gxTv_SdtRepair_Gamename_Z = "";
         return  ;
      }

      public bool gxTv_SdtRepair_Gamename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairCost_Z" )]
      [  XmlElement( ElementName = "RepairCost_Z"   )]
      public short gxTpr_Repaircost_Z
      {
         get {
            return gxTv_SdtRepair_Repaircost_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repaircost_Z = value;
            SetDirty("Repaircost_Z");
         }

      }

      public void gxTv_SdtRepair_Repaircost_Z_SetNull( )
      {
         gxTv_SdtRepair_Repaircost_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repaircost_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TechnicianId_Z" )]
      [  XmlElement( ElementName = "TechnicianId_Z"   )]
      public short gxTpr_Technicianid_Z
      {
         get {
            return gxTv_SdtRepair_Technicianid_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Technicianid_Z = value;
            SetDirty("Technicianid_Z");
         }

      }

      public void gxTv_SdtRepair_Technicianid_Z_SetNull( )
      {
         gxTv_SdtRepair_Technicianid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Technicianid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TechnicianName_Z" )]
      [  XmlElement( ElementName = "TechnicianName_Z"   )]
      public string gxTpr_Technicianname_Z
      {
         get {
            return gxTv_SdtRepair_Technicianname_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Technicianname_Z = value;
            SetDirty("Technicianname_Z");
         }

      }

      public void gxTv_SdtRepair_Technicianname_Z_SetNull( )
      {
         gxTv_SdtRepair_Technicianname_Z = "";
         return  ;
      }

      public bool gxTv_SdtRepair_Technicianname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairAlternateTechnicianId_Z" )]
      [  XmlElement( ElementName = "RepairAlternateTechnicianId_Z"   )]
      public short gxTpr_Repairalternatetechnicianid_Z
      {
         get {
            return gxTv_SdtRepair_Repairalternatetechnicianid_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairalternatetechnicianid_Z = value;
            SetDirty("Repairalternatetechnicianid_Z");
         }

      }

      public void gxTv_SdtRepair_Repairalternatetechnicianid_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairalternatetechnicianid_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairalternatetechnicianid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairAlternateTechnicianName_Z" )]
      [  XmlElement( ElementName = "RepairAlternateTechnicianName_Z"   )]
      public string gxTpr_Repairalternatetechnicianname_Z
      {
         get {
            return gxTv_SdtRepair_Repairalternatetechnicianname_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairalternatetechnicianname_Z = value;
            SetDirty("Repairalternatetechnicianname_Z");
         }

      }

      public void gxTv_SdtRepair_Repairalternatetechnicianname_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairalternatetechnicianname_Z = "";
         return  ;
      }

      public bool gxTv_SdtRepair_Repairalternatetechnicianname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairDiscountPercentage_Z" )]
      [  XmlElement( ElementName = "RepairDiscountPercentage_Z"   )]
      public short gxTpr_Repairdiscountpercentage_Z
      {
         get {
            return gxTv_SdtRepair_Repairdiscountpercentage_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairdiscountpercentage_Z = value;
            SetDirty("Repairdiscountpercentage_Z");
         }

      }

      public void gxTv_SdtRepair_Repairdiscountpercentage_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairdiscountpercentage_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairdiscountpercentage_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairFinalCost_Z" )]
      [  XmlElement( ElementName = "RepairFinalCost_Z"   )]
      public short gxTpr_Repairfinalcost_Z
      {
         get {
            return gxTv_SdtRepair_Repairfinalcost_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairfinalcost_Z = value;
            SetDirty("Repairfinalcost_Z");
         }

      }

      public void gxTv_SdtRepair_Repairfinalcost_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairfinalcost_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairfinalcost_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairProblems_Z" )]
      [  XmlElement( ElementName = "RepairProblems_Z"   )]
      public short gxTpr_Repairproblems_Z
      {
         get {
            return gxTv_SdtRepair_Repairproblems_Z ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairproblems_Z = value;
            SetDirty("Repairproblems_Z");
         }

      }

      public void gxTv_SdtRepair_Repairproblems_Z_SetNull( )
      {
         gxTv_SdtRepair_Repairproblems_Z = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairproblems_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RepairProblems_N" )]
      [  XmlElement( ElementName = "RepairProblems_N"   )]
      public short gxTpr_Repairproblems_N
      {
         get {
            return gxTv_SdtRepair_Repairproblems_N ;
         }

         set {
            gxTv_SdtRepair_N = 0;
            gxTv_SdtRepair_Repairproblems_N = value;
            SetDirty("Repairproblems_N");
         }

      }

      public void gxTv_SdtRepair_Repairproblems_N_SetNull( )
      {
         gxTv_SdtRepair_Repairproblems_N = 0;
         return  ;
      }

      public bool gxTv_SdtRepair_Repairproblems_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtRepair_N = 1;
         gxTv_SdtRepair_Repairdatefrom = DateTime.MinValue;
         gxTv_SdtRepair_Repairdateto = DateTime.MinValue;
         gxTv_SdtRepair_Gamename = "";
         gxTv_SdtRepair_Technicianname = "";
         gxTv_SdtRepair_Repairalternatetechnicianname = "";
         gxTv_SdtRepair_Mode = "";
         gxTv_SdtRepair_Repairdatefrom_Z = DateTime.MinValue;
         gxTv_SdtRepair_Repairdateto_Z = DateTime.MinValue;
         gxTv_SdtRepair_Gamename_Z = "";
         gxTv_SdtRepair_Technicianname_Z = "";
         gxTv_SdtRepair_Repairalternatetechnicianname_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "repair", "GeneXus.Programs.repair_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtRepair_N ;
      }

      private short gxTv_SdtRepair_Repairid ;
      private short gxTv_SdtRepair_N ;
      private short gxTv_SdtRepair_Repairdaysquantity ;
      private short gxTv_SdtRepair_Gameid ;
      private short gxTv_SdtRepair_Repaircost ;
      private short gxTv_SdtRepair_Technicianid ;
      private short gxTv_SdtRepair_Repairalternatetechnicianid ;
      private short gxTv_SdtRepair_Repairdiscountpercentage ;
      private short gxTv_SdtRepair_Repairfinalcost ;
      private short gxTv_SdtRepair_Repairproblems ;
      private short gxTv_SdtRepair_Initialized ;
      private short gxTv_SdtRepair_Repairid_Z ;
      private short gxTv_SdtRepair_Repairdaysquantity_Z ;
      private short gxTv_SdtRepair_Gameid_Z ;
      private short gxTv_SdtRepair_Repaircost_Z ;
      private short gxTv_SdtRepair_Technicianid_Z ;
      private short gxTv_SdtRepair_Repairalternatetechnicianid_Z ;
      private short gxTv_SdtRepair_Repairdiscountpercentage_Z ;
      private short gxTv_SdtRepair_Repairfinalcost_Z ;
      private short gxTv_SdtRepair_Repairproblems_Z ;
      private short gxTv_SdtRepair_Repairproblems_N ;
      private string gxTv_SdtRepair_Gamename ;
      private string gxTv_SdtRepair_Technicianname ;
      private string gxTv_SdtRepair_Repairalternatetechnicianname ;
      private string gxTv_SdtRepair_Mode ;
      private string gxTv_SdtRepair_Gamename_Z ;
      private string gxTv_SdtRepair_Technicianname_Z ;
      private string gxTv_SdtRepair_Repairalternatetechnicianname_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtRepair_Repairdatefrom ;
      private DateTime gxTv_SdtRepair_Repairdateto ;
      private DateTime gxTv_SdtRepair_Repairdatefrom_Z ;
      private DateTime gxTv_SdtRepair_Repairdateto_Z ;
      private GXBCLevelCollection<SdtRepair_Kind> gxTv_SdtRepair_Kind=null ;
   }

   [DataContract(Name = @"Repair", Namespace = "Parksz")]
   public class SdtRepair_RESTInterface : GxGenericCollectionItem<SdtRepair>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRepair_RESTInterface( ) : base()
      {
      }

      public SdtRepair_RESTInterface( SdtRepair psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RepairId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Repairid
      {
         get {
            return sdt.gxTpr_Repairid ;
         }

         set {
            sdt.gxTpr_Repairid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RepairDateFrom" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Repairdatefrom
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Repairdatefrom) ;
         }

         set {
            sdt.gxTpr_Repairdatefrom = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "RepairDaysQuantity" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Repairdaysquantity
      {
         get {
            return sdt.gxTpr_Repairdaysquantity ;
         }

         set {
            sdt.gxTpr_Repairdaysquantity = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RepairDateTo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Repairdateto
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Repairdateto) ;
         }

         set {
            sdt.gxTpr_Repairdateto = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "GameId" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Gameid
      {
         get {
            return sdt.gxTpr_Gameid ;
         }

         set {
            sdt.gxTpr_Gameid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "GameName" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Gamename
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Gamename) ;
         }

         set {
            sdt.gxTpr_Gamename = value;
         }

      }

      [DataMember( Name = "RepairCost" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Repaircost
      {
         get {
            return sdt.gxTpr_Repaircost ;
         }

         set {
            sdt.gxTpr_Repaircost = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TechnicianId" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Technicianid
      {
         get {
            return sdt.gxTpr_Technicianid ;
         }

         set {
            sdt.gxTpr_Technicianid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TechnicianName" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Technicianname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Technicianname) ;
         }

         set {
            sdt.gxTpr_Technicianname = value;
         }

      }

      [DataMember( Name = "RepairAlternateTechnicianId" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Repairalternatetechnicianid
      {
         get {
            return sdt.gxTpr_Repairalternatetechnicianid ;
         }

         set {
            sdt.gxTpr_Repairalternatetechnicianid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RepairAlternateTechnicianName" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Repairalternatetechnicianname
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Repairalternatetechnicianname) ;
         }

         set {
            sdt.gxTpr_Repairalternatetechnicianname = value;
         }

      }

      [DataMember( Name = "RepairDiscountPercentage" , Order = 11 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Repairdiscountpercentage
      {
         get {
            return sdt.gxTpr_Repairdiscountpercentage ;
         }

         set {
            sdt.gxTpr_Repairdiscountpercentage = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RepairFinalCost" , Order = 12 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Repairfinalcost
      {
         get {
            return sdt.gxTpr_Repairfinalcost ;
         }

         set {
            sdt.gxTpr_Repairfinalcost = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RepairProblems" , Order = 13 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Repairproblems
      {
         get {
            return sdt.gxTpr_Repairproblems ;
         }

         set {
            sdt.gxTpr_Repairproblems = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Kind" , Order = 14 )]
      public GxGenericCollection<SdtRepair_Kind_RESTInterface> gxTpr_Kind
      {
         get {
            return new GxGenericCollection<SdtRepair_Kind_RESTInterface>(sdt.gxTpr_Kind) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Kind);
         }

      }

      public SdtRepair sdt
      {
         get {
            return (SdtRepair)Sdt ;
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
            sdt = new SdtRepair() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 15 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Repair", Namespace = "Parksz")]
   public class SdtRepair_RESTLInterface : GxGenericCollectionItem<SdtRepair>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRepair_RESTLInterface( ) : base()
      {
      }

      public SdtRepair_RESTLInterface( SdtRepair psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RepairDateFrom" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Repairdatefrom
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Repairdatefrom) ;
         }

         set {
            sdt.gxTpr_Repairdatefrom = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtRepair sdt
      {
         get {
            return (SdtRepair)Sdt ;
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
            sdt = new SdtRepair() ;
         }
      }

   }

}
