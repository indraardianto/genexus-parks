using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class repair_bc : GXHttpHandler, IGxSilentTrn
   {
      public repair_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public repair_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow067( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey067( ) ;
         standaloneModal( ) ;
         AddRow067( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z22RepairId = A22RepairId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_060( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls067( ) ;
            }
            else
            {
               CheckExtendedTable067( ) ;
               if ( AnyError == 0 )
               {
                  ZM067( 7) ;
                  ZM067( 8) ;
                  ZM067( 9) ;
                  ZM067( 10) ;
               }
               CloseExtendedTableCursors067( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode7 = Gx_mode;
            CONFIRM_069( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode7;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode7;
         }
      }

      protected void CONFIRM_069( )
      {
         s36RepairProblems = O36RepairProblems;
         n36RepairProblems = false;
         nGXsfl_9_idx = 0;
         while ( nGXsfl_9_idx < bcRepair.gxTpr_Kind.Count )
         {
            ReadRow069( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound9 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_9 != 0 ) )
            {
               GetKey069( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound9 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate069( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable069( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors069( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O36RepairProblems = A36RepairProblems;
                        n36RepairProblems = false;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey069( ) ;
                        Load069( ) ;
                        BeforeValidate069( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls069( ) ;
                           O36RepairProblems = A36RepairProblems;
                           n36RepairProblems = false;
                        }
                     }
                     else
                     {
                        if ( nIsMod_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate069( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable069( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors069( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O36RepairProblems = A36RepairProblems;
                              n36RepairProblems = false;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow9( ((SdtRepair_Kind)bcRepair.gxTpr_Kind.Item(nGXsfl_9_idx))) ;
            }
         }
         O36RepairProblems = s36RepairProblems;
         n36RepairProblems = false;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ZM067( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z23RepairDateFrom = A23RepairDateFrom;
            Z24RepairDaysQuantity = A24RepairDaysQuantity;
            Z26RepairCost = A26RepairCost;
            Z31RepairDiscountPercentage = A31RepairDiscountPercentage;
            Z16GameId = A16GameId;
            Z27TechnicianId = A27TechnicianId;
            Z29RepairAlternateTechnicianId = A29RepairAlternateTechnicianId;
            Z25RepairDateTo = A25RepairDateTo;
            Z32RepairFinalCost = A32RepairFinalCost;
            Z36RepairProblems = A36RepairProblems;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z17GameName = A17GameName;
            Z25RepairDateTo = A25RepairDateTo;
            Z32RepairFinalCost = A32RepairFinalCost;
            Z36RepairProblems = A36RepairProblems;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z28TechnicianName = A28TechnicianName;
            Z25RepairDateTo = A25RepairDateTo;
            Z32RepairFinalCost = A32RepairFinalCost;
            Z36RepairProblems = A36RepairProblems;
         }
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z30RepairAlternateTechnicianName = A30RepairAlternateTechnicianName;
            Z25RepairDateTo = A25RepairDateTo;
            Z32RepairFinalCost = A32RepairFinalCost;
            Z36RepairProblems = A36RepairProblems;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z25RepairDateTo = A25RepairDateTo;
            Z32RepairFinalCost = A32RepairFinalCost;
            Z36RepairProblems = A36RepairProblems;
         }
         if ( GX_JID == -6 )
         {
            Z22RepairId = A22RepairId;
            Z23RepairDateFrom = A23RepairDateFrom;
            Z24RepairDaysQuantity = A24RepairDaysQuantity;
            Z26RepairCost = A26RepairCost;
            Z31RepairDiscountPercentage = A31RepairDiscountPercentage;
            Z16GameId = A16GameId;
            Z27TechnicianId = A27TechnicianId;
            Z29RepairAlternateTechnicianId = A29RepairAlternateTechnicianId;
            Z36RepairProblems = A36RepairProblems;
            Z17GameName = A17GameName;
            Z28TechnicianName = A28TechnicianName;
            Z30RepairAlternateTechnicianName = A30RepairAlternateTechnicianName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load067( )
      {
         /* Using cursor BC000612 */
         pr_default.execute(8, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound7 = 1;
            A23RepairDateFrom = BC000612_A23RepairDateFrom[0];
            A24RepairDaysQuantity = BC000612_A24RepairDaysQuantity[0];
            A17GameName = BC000612_A17GameName[0];
            A26RepairCost = BC000612_A26RepairCost[0];
            A28TechnicianName = BC000612_A28TechnicianName[0];
            A30RepairAlternateTechnicianName = BC000612_A30RepairAlternateTechnicianName[0];
            A31RepairDiscountPercentage = BC000612_A31RepairDiscountPercentage[0];
            A16GameId = BC000612_A16GameId[0];
            A27TechnicianId = BC000612_A27TechnicianId[0];
            A29RepairAlternateTechnicianId = BC000612_A29RepairAlternateTechnicianId[0];
            A36RepairProblems = BC000612_A36RepairProblems[0];
            n36RepairProblems = BC000612_n36RepairProblems[0];
            ZM067( -6) ;
         }
         pr_default.close(8);
         OnLoadActions067( ) ;
      }

      protected void OnLoadActions067( )
      {
         O36RepairProblems = A36RepairProblems;
         n36RepairProblems = false;
         A25RepairDateTo = DateTimeUtil.DAdd(A23RepairDateFrom,+((int)(A24RepairDaysQuantity)));
         A32RepairFinalCost = (short)(A26RepairCost*(1-A31RepairDiscountPercentage/ (decimal)(100)));
      }

      protected void CheckExtendedTable067( )
      {
         nIsDirty_7 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000610 */
         pr_default.execute(7, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A36RepairProblems = BC000610_A36RepairProblems[0];
            n36RepairProblems = BC000610_n36RepairProblems[0];
         }
         else
         {
            nIsDirty_7 = 1;
            A36RepairProblems = 0;
            n36RepairProblems = false;
         }
         pr_default.close(7);
         if ( ! ( (DateTime.MinValue==A23RepairDateFrom) || ( DateTimeUtil.ResetTime ( A23RepairDateFrom ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Repair Date From is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         nIsDirty_7 = 1;
         A25RepairDateTo = DateTimeUtil.DAdd(A23RepairDateFrom,+((int)(A24RepairDaysQuantity)));
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A16GameId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Game'.", "ForeignKeyNotFound", 1, "GAMEID");
            AnyError = 1;
         }
         A17GameName = BC00066_A17GameName[0];
         pr_default.close(4);
         nIsDirty_7 = 1;
         A32RepairFinalCost = (short)(A26RepairCost*(1-A31RepairDiscountPercentage/ (decimal)(100)));
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {A27TechnicianId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Technician'.", "ForeignKeyNotFound", 1, "TECHNICIANID");
            AnyError = 1;
         }
         A28TechnicianName = BC00067_A28TechnicianName[0];
         pr_default.close(5);
         /* Using cursor BC00068 */
         pr_default.execute(6, new Object[] {A29RepairAlternateTechnicianId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Repair Alternate Technician'.", "ForeignKeyNotFound", 1, "REPAIRALTERNATETECHNICIANID");
            AnyError = 1;
         }
         A30RepairAlternateTechnicianName = BC00068_A30RepairAlternateTechnicianName[0];
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors067( )
      {
         pr_default.close(7);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey067( )
      {
         /* Using cursor BC000613 */
         pr_default.execute(9, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM067( 6) ;
            RcdFound7 = 1;
            A22RepairId = BC00065_A22RepairId[0];
            A23RepairDateFrom = BC00065_A23RepairDateFrom[0];
            A24RepairDaysQuantity = BC00065_A24RepairDaysQuantity[0];
            A26RepairCost = BC00065_A26RepairCost[0];
            A31RepairDiscountPercentage = BC00065_A31RepairDiscountPercentage[0];
            A16GameId = BC00065_A16GameId[0];
            A27TechnicianId = BC00065_A27TechnicianId[0];
            A29RepairAlternateTechnicianId = BC00065_A29RepairAlternateTechnicianId[0];
            Z22RepairId = A22RepairId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load067( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey067( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey067( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey067( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_060( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency067( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00064 */
            pr_default.execute(2, new Object[] {A22RepairId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Repair"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( DateTimeUtil.ResetTime ( Z23RepairDateFrom ) != DateTimeUtil.ResetTime ( BC00064_A23RepairDateFrom[0] ) ) || ( Z24RepairDaysQuantity != BC00064_A24RepairDaysQuantity[0] ) || ( Z26RepairCost != BC00064_A26RepairCost[0] ) || ( Z31RepairDiscountPercentage != BC00064_A31RepairDiscountPercentage[0] ) || ( Z16GameId != BC00064_A16GameId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z27TechnicianId != BC00064_A27TechnicianId[0] ) || ( Z29RepairAlternateTechnicianId != BC00064_A29RepairAlternateTechnicianId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Repair"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM067( 0) ;
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000614 */
                     pr_default.execute(10, new Object[] {A23RepairDateFrom, A24RepairDaysQuantity, A26RepairCost, A31RepairDiscountPercentage, A16GameId, A27TechnicianId, A29RepairAlternateTechnicianId});
                     A22RepairId = BC000614_A22RepairId[0];
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("Repair");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel067( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load067( ) ;
            }
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void Update067( )
      {
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable067( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm067( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate067( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000615 */
                     pr_default.execute(11, new Object[] {A23RepairDateFrom, A24RepairDaysQuantity, A26RepairCost, A31RepairDiscountPercentage, A16GameId, A27TechnicianId, A29RepairAlternateTechnicianId, A22RepairId});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("Repair");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Repair"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate067( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel067( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel067( ) ;
         }
         CloseExtendedTableCursors067( ) ;
      }

      protected void DeferredUpdate067( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate067( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency067( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls067( ) ;
            AfterConfirm067( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete067( ) ;
               if ( AnyError == 0 )
               {
                  A36RepairProblems = O36RepairProblems;
                  n36RepairProblems = false;
                  ScanKeyStart069( ) ;
                  while ( RcdFound9 != 0 )
                  {
                     getByPrimaryKey069( ) ;
                     Delete069( ) ;
                     ScanKeyNext069( ) ;
                     O36RepairProblems = A36RepairProblems;
                     n36RepairProblems = false;
                  }
                  ScanKeyEnd069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000616 */
                     pr_default.execute(12, new Object[] {A22RepairId});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("Repair");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
         }
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel067( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls067( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000618 */
            pr_default.execute(13, new Object[] {A22RepairId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               A36RepairProblems = BC000618_A36RepairProblems[0];
               n36RepairProblems = BC000618_n36RepairProblems[0];
            }
            else
            {
               A36RepairProblems = 0;
               n36RepairProblems = false;
            }
            pr_default.close(13);
            A25RepairDateTo = DateTimeUtil.DAdd(A23RepairDateFrom,+((int)(A24RepairDaysQuantity)));
            /* Using cursor BC000619 */
            pr_default.execute(14, new Object[] {A16GameId});
            A17GameName = BC000619_A17GameName[0];
            pr_default.close(14);
            /* Using cursor BC000620 */
            pr_default.execute(15, new Object[] {A27TechnicianId});
            A28TechnicianName = BC000620_A28TechnicianName[0];
            pr_default.close(15);
            /* Using cursor BC000621 */
            pr_default.execute(16, new Object[] {A29RepairAlternateTechnicianId});
            A30RepairAlternateTechnicianName = BC000621_A30RepairAlternateTechnicianName[0];
            pr_default.close(16);
            A32RepairFinalCost = (short)(A26RepairCost*(1-A31RepairDiscountPercentage/ (decimal)(100)));
         }
      }

      protected void ProcessNestedLevel069( )
      {
         s36RepairProblems = O36RepairProblems;
         n36RepairProblems = false;
         nGXsfl_9_idx = 0;
         while ( nGXsfl_9_idx < bcRepair.gxTpr_Kind.Count )
         {
            ReadRow069( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound9 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_9 != 0 ) )
            {
               standaloneNotModal069( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert069( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete069( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update069( ) ;
                  }
               }
               O36RepairProblems = A36RepairProblems;
               n36RepairProblems = false;
            }
            KeyVarsToRow9( ((SdtRepair_Kind)bcRepair.gxTpr_Kind.Item(nGXsfl_9_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_9_idx = 0;
            while ( nGXsfl_9_idx < bcRepair.gxTpr_Kind.Count )
            {
               ReadRow069( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound9 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcRepair.gxTpr_Kind.RemoveElement(nGXsfl_9_idx);
                  nGXsfl_9_idx = (int)(nGXsfl_9_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey069( ) ;
                  VarsToRow9( ((SdtRepair_Kind)bcRepair.gxTpr_Kind.Item(nGXsfl_9_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll069( ) ;
         if ( AnyError != 0 )
         {
            O36RepairProblems = s36RepairProblems;
            n36RepairProblems = false;
         }
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         Gxremove9 = 0;
      }

      protected void ProcessLevel067( )
      {
         /* Save parent mode. */
         sMode7 = Gx_mode;
         ProcessNestedLevel069( ) ;
         if ( AnyError != 0 )
         {
            O36RepairProblems = s36RepairProblems;
            n36RepairProblems = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode7;
         /* ' Update level parameters */
      }

      protected void EndLevel067( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete067( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart067( )
      {
         /* Using cursor BC000623 */
         pr_default.execute(17, new Object[] {A22RepairId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound7 = 1;
            A22RepairId = BC000623_A22RepairId[0];
            A23RepairDateFrom = BC000623_A23RepairDateFrom[0];
            A24RepairDaysQuantity = BC000623_A24RepairDaysQuantity[0];
            A17GameName = BC000623_A17GameName[0];
            A26RepairCost = BC000623_A26RepairCost[0];
            A28TechnicianName = BC000623_A28TechnicianName[0];
            A30RepairAlternateTechnicianName = BC000623_A30RepairAlternateTechnicianName[0];
            A31RepairDiscountPercentage = BC000623_A31RepairDiscountPercentage[0];
            A16GameId = BC000623_A16GameId[0];
            A27TechnicianId = BC000623_A27TechnicianId[0];
            A29RepairAlternateTechnicianId = BC000623_A29RepairAlternateTechnicianId[0];
            A36RepairProblems = BC000623_A36RepairProblems[0];
            n36RepairProblems = BC000623_n36RepairProblems[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext067( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound7 = 0;
         ScanKeyLoad067( ) ;
      }

      protected void ScanKeyLoad067( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound7 = 1;
            A22RepairId = BC000623_A22RepairId[0];
            A23RepairDateFrom = BC000623_A23RepairDateFrom[0];
            A24RepairDaysQuantity = BC000623_A24RepairDaysQuantity[0];
            A17GameName = BC000623_A17GameName[0];
            A26RepairCost = BC000623_A26RepairCost[0];
            A28TechnicianName = BC000623_A28TechnicianName[0];
            A30RepairAlternateTechnicianName = BC000623_A30RepairAlternateTechnicianName[0];
            A31RepairDiscountPercentage = BC000623_A31RepairDiscountPercentage[0];
            A16GameId = BC000623_A16GameId[0];
            A27TechnicianId = BC000623_A27TechnicianId[0];
            A29RepairAlternateTechnicianId = BC000623_A29RepairAlternateTechnicianId[0];
            A36RepairProblems = BC000623_A36RepairProblems[0];
            n36RepairProblems = BC000623_n36RepairProblems[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd067( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm067( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert067( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate067( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete067( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete067( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate067( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes067( )
      {
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z37RepairKindName = A37RepairKindName;
            Z35RepairKindRemarks = A35RepairKindRemarks;
         }
         if ( GX_JID == -11 )
         {
            Z22RepairId = A22RepairId;
            Z33RepairKindId = A33RepairKindId;
            Z37RepairKindName = A37RepairKindName;
            Z35RepairKindRemarks = A35RepairKindRemarks;
         }
      }

      protected void standaloneNotModal069( )
      {
      }

      protected void standaloneModal069( )
      {
      }

      protected void Load069( )
      {
         /* Using cursor BC000624 */
         pr_default.execute(18, new Object[] {A22RepairId, A33RepairKindId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound9 = 1;
            A37RepairKindName = BC000624_A37RepairKindName[0];
            A35RepairKindRemarks = BC000624_A35RepairKindRemarks[0];
            ZM069( -11) ;
         }
         pr_default.close(18);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         if ( IsIns( )  )
         {
            A36RepairProblems = (short)(O36RepairProblems+1);
            n36RepairProblems = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A36RepairProblems = O36RepairProblems;
               n36RepairProblems = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A36RepairProblems = (short)(O36RepairProblems-1);
                  n36RepairProblems = false;
               }
            }
         }
      }

      protected void CheckExtendedTable069( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal069( ) ;
         Gx_BScreen = 0;
         if ( ! ( ( StringUtil.StrCmp(A37RepairKindName, "E") == 0 ) || ( StringUtil.StrCmp(A37RepairKindName, "M") == 0 ) || ( StringUtil.StrCmp(A37RepairKindName, "R") == 0 ) ) )
         {
            GX_msglist.addItem("Field Repair Kind Name is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( IsIns( )  )
         {
            nIsDirty_9 = 1;
            A36RepairProblems = (short)(O36RepairProblems+1);
            n36RepairProblems = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_9 = 1;
               A36RepairProblems = O36RepairProblems;
               n36RepairProblems = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_9 = 1;
                  A36RepairProblems = (short)(O36RepairProblems-1);
                  n36RepairProblems = false;
               }
            }
         }
      }

      protected void CloseExtendedTableCursors069( )
      {
      }

      protected void enableDisable069( )
      {
      }

      protected void GetKey069( )
      {
         /* Using cursor BC000625 */
         pr_default.execute(19, new Object[] {A22RepairId, A33RepairKindId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey069( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A22RepairId, A33RepairKindId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM069( 11) ;
            RcdFound9 = 1;
            InitializeNonKey069( ) ;
            A33RepairKindId = BC00063_A33RepairKindId[0];
            A37RepairKindName = BC00063_A37RepairKindName[0];
            A35RepairKindRemarks = BC00063_A35RepairKindRemarks[0];
            Z22RepairId = A22RepairId;
            Z33RepairKindId = A33RepairKindId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal069( ) ;
            Load069( ) ;
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal069( ) ;
            Gx_mode = sMode9;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes069( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A22RepairId, A33RepairKindId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RepairRepairTransaction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z37RepairKindName, BC00062_A37RepairKindName[0]) != 0 ) || ( StringUtil.StrCmp(Z35RepairKindRemarks, BC00062_A35RepairKindRemarks[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"RepairRepairTransaction"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM069( 0) ;
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000626 */
                     pr_default.execute(20, new Object[] {A22RepairId, A33RepairKindId, A37RepairKindName, A35RepairKindRemarks});
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("RepairRepairTransaction");
                     if ( (pr_default.getStatus(20) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load069( ) ;
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void Update069( )
      {
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable069( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000627 */
                     pr_default.execute(21, new Object[] {A37RepairKindName, A35RepairKindRemarks, A22RepairId, A33RepairKindId});
                     pr_default.close(21);
                     dsDefault.SmartCacheProvider.SetUpdated("RepairRepairTransaction");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RepairRepairTransaction"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate069( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey069( ) ;
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel069( ) ;
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void Delete069( )
      {
         Gx_mode = "DLT";
         BeforeValidate069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls069( ) ;
            AfterConfirm069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete069( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000628 */
                  pr_default.execute(22, new Object[] {A22RepairId, A33RepairKindId});
                  pr_default.close(22);
                  dsDefault.SmartCacheProvider.SetUpdated("RepairRepairTransaction");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel069( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls069( )
      {
         standaloneModal069( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            if ( IsIns( )  )
            {
               A36RepairProblems = (short)(O36RepairProblems+1);
               n36RepairProblems = false;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A36RepairProblems = O36RepairProblems;
                  n36RepairProblems = false;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A36RepairProblems = (short)(O36RepairProblems-1);
                     n36RepairProblems = false;
                  }
               }
            }
         }
      }

      protected void EndLevel069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart069( )
      {
         /* Scan By routine */
         /* Using cursor BC000629 */
         pr_default.execute(23, new Object[] {A22RepairId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound9 = 1;
            A33RepairKindId = BC000629_A33RepairKindId[0];
            A37RepairKindName = BC000629_A37RepairKindName[0];
            A35RepairKindRemarks = BC000629_A35RepairKindRemarks[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound9 = 0;
         ScanKeyLoad069( ) ;
      }

      protected void ScanKeyLoad069( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound9 = 1;
            A33RepairKindId = BC000629_A33RepairKindId[0];
            A37RepairKindName = BC000629_A37RepairKindName[0];
            A35RepairKindRemarks = BC000629_A35RepairKindRemarks[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd069( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete069( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes069( )
      {
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void send_integrity_lvl_hashes067( )
      {
      }

      protected void AddRow067( )
      {
         VarsToRow7( bcRepair) ;
      }

      protected void ReadRow067( )
      {
         RowToVars7( bcRepair, 1) ;
      }

      protected void AddRow069( )
      {
         SdtRepair_Kind obj9;
         obj9 = new SdtRepair_Kind(context);
         VarsToRow9( obj9) ;
         bcRepair.gxTpr_Kind.Add(obj9, 0);
         obj9.gxTpr_Mode = "UPD";
         obj9.gxTpr_Modified = 0;
      }

      protected void ReadRow069( )
      {
         nGXsfl_9_idx = (int)(nGXsfl_9_idx+1);
         RowToVars9( ((SdtRepair_Kind)bcRepair.gxTpr_Kind.Item(nGXsfl_9_idx)), 1) ;
      }

      protected void InitializeNonKey067( )
      {
         A32RepairFinalCost = 0;
         A25RepairDateTo = DateTime.MinValue;
         A23RepairDateFrom = DateTime.MinValue;
         A24RepairDaysQuantity = 0;
         A16GameId = 0;
         A17GameName = "";
         A26RepairCost = 0;
         A27TechnicianId = 0;
         A28TechnicianName = "";
         A29RepairAlternateTechnicianId = 0;
         A30RepairAlternateTechnicianName = "";
         A31RepairDiscountPercentage = 0;
         A36RepairProblems = 0;
         n36RepairProblems = false;
         O36RepairProblems = A36RepairProblems;
         n36RepairProblems = false;
         Z23RepairDateFrom = DateTime.MinValue;
         Z24RepairDaysQuantity = 0;
         Z26RepairCost = 0;
         Z31RepairDiscountPercentage = 0;
         Z16GameId = 0;
         Z27TechnicianId = 0;
         Z29RepairAlternateTechnicianId = 0;
      }

      protected void InitAll067( )
      {
         A22RepairId = 0;
         InitializeNonKey067( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey069( )
      {
         A37RepairKindName = "";
         A35RepairKindRemarks = "";
         Z37RepairKindName = "";
         Z35RepairKindRemarks = "";
      }

      protected void InitAll069( )
      {
         A33RepairKindId = 0;
         InitializeNonKey069( ) ;
      }

      protected void StandaloneModalInsert069( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow7( SdtRepair obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Repairfinalcost = A32RepairFinalCost;
         obj7.gxTpr_Repairdateto = A25RepairDateTo;
         obj7.gxTpr_Repairdatefrom = A23RepairDateFrom;
         obj7.gxTpr_Repairdaysquantity = A24RepairDaysQuantity;
         obj7.gxTpr_Gameid = A16GameId;
         obj7.gxTpr_Gamename = A17GameName;
         obj7.gxTpr_Repaircost = A26RepairCost;
         obj7.gxTpr_Technicianid = A27TechnicianId;
         obj7.gxTpr_Technicianname = A28TechnicianName;
         obj7.gxTpr_Repairalternatetechnicianid = A29RepairAlternateTechnicianId;
         obj7.gxTpr_Repairalternatetechnicianname = A30RepairAlternateTechnicianName;
         obj7.gxTpr_Repairdiscountpercentage = A31RepairDiscountPercentage;
         obj7.gxTpr_Repairproblems = A36RepairProblems;
         obj7.gxTpr_Repairid = A22RepairId;
         obj7.gxTpr_Repairid_Z = Z22RepairId;
         obj7.gxTpr_Repairdatefrom_Z = Z23RepairDateFrom;
         obj7.gxTpr_Repairdaysquantity_Z = Z24RepairDaysQuantity;
         obj7.gxTpr_Repairdateto_Z = Z25RepairDateTo;
         obj7.gxTpr_Gameid_Z = Z16GameId;
         obj7.gxTpr_Gamename_Z = Z17GameName;
         obj7.gxTpr_Repaircost_Z = Z26RepairCost;
         obj7.gxTpr_Technicianid_Z = Z27TechnicianId;
         obj7.gxTpr_Technicianname_Z = Z28TechnicianName;
         obj7.gxTpr_Repairalternatetechnicianid_Z = Z29RepairAlternateTechnicianId;
         obj7.gxTpr_Repairalternatetechnicianname_Z = Z30RepairAlternateTechnicianName;
         obj7.gxTpr_Repairdiscountpercentage_Z = Z31RepairDiscountPercentage;
         obj7.gxTpr_Repairfinalcost_Z = Z32RepairFinalCost;
         obj7.gxTpr_Repairproblems_Z = Z36RepairProblems;
         obj7.gxTpr_Repairproblems_N = (short)(Convert.ToInt16(n36RepairProblems));
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( SdtRepair obj7 )
      {
         obj7.gxTpr_Repairid = A22RepairId;
         return  ;
      }

      public void RowToVars7( SdtRepair obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A32RepairFinalCost = obj7.gxTpr_Repairfinalcost;
         A25RepairDateTo = obj7.gxTpr_Repairdateto;
         A23RepairDateFrom = obj7.gxTpr_Repairdatefrom;
         A24RepairDaysQuantity = obj7.gxTpr_Repairdaysquantity;
         A16GameId = obj7.gxTpr_Gameid;
         A17GameName = obj7.gxTpr_Gamename;
         A26RepairCost = obj7.gxTpr_Repaircost;
         A27TechnicianId = obj7.gxTpr_Technicianid;
         A28TechnicianName = obj7.gxTpr_Technicianname;
         A29RepairAlternateTechnicianId = obj7.gxTpr_Repairalternatetechnicianid;
         A30RepairAlternateTechnicianName = obj7.gxTpr_Repairalternatetechnicianname;
         A31RepairDiscountPercentage = obj7.gxTpr_Repairdiscountpercentage;
         A36RepairProblems = obj7.gxTpr_Repairproblems;
         n36RepairProblems = false;
         A22RepairId = obj7.gxTpr_Repairid;
         Z22RepairId = obj7.gxTpr_Repairid_Z;
         Z23RepairDateFrom = obj7.gxTpr_Repairdatefrom_Z;
         Z24RepairDaysQuantity = obj7.gxTpr_Repairdaysquantity_Z;
         Z25RepairDateTo = obj7.gxTpr_Repairdateto_Z;
         Z16GameId = obj7.gxTpr_Gameid_Z;
         Z17GameName = obj7.gxTpr_Gamename_Z;
         Z26RepairCost = obj7.gxTpr_Repaircost_Z;
         Z27TechnicianId = obj7.gxTpr_Technicianid_Z;
         Z28TechnicianName = obj7.gxTpr_Technicianname_Z;
         Z29RepairAlternateTechnicianId = obj7.gxTpr_Repairalternatetechnicianid_Z;
         Z30RepairAlternateTechnicianName = obj7.gxTpr_Repairalternatetechnicianname_Z;
         Z31RepairDiscountPercentage = obj7.gxTpr_Repairdiscountpercentage_Z;
         Z32RepairFinalCost = obj7.gxTpr_Repairfinalcost_Z;
         Z36RepairProblems = obj7.gxTpr_Repairproblems_Z;
         O36RepairProblems = obj7.gxTpr_Repairproblems_Z;
         n36RepairProblems = (bool)(Convert.ToBoolean(obj7.gxTpr_Repairproblems_N));
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow9( SdtRepair_Kind obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Repairkindname = A37RepairKindName;
         obj9.gxTpr_Repairkindremarks = A35RepairKindRemarks;
         obj9.gxTpr_Repairkindid = A33RepairKindId;
         obj9.gxTpr_Repairkindid_Z = Z33RepairKindId;
         obj9.gxTpr_Repairkindname_Z = Z37RepairKindName;
         obj9.gxTpr_Repairkindremarks_Z = Z35RepairKindRemarks;
         obj9.gxTpr_Modified = nIsMod_9;
         return  ;
      }

      public void KeyVarsToRow9( SdtRepair_Kind obj9 )
      {
         obj9.gxTpr_Repairkindid = A33RepairKindId;
         return  ;
      }

      public void RowToVars9( SdtRepair_Kind obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A37RepairKindName = obj9.gxTpr_Repairkindname;
         A35RepairKindRemarks = obj9.gxTpr_Repairkindremarks;
         A33RepairKindId = obj9.gxTpr_Repairkindid;
         Z33RepairKindId = obj9.gxTpr_Repairkindid_Z;
         Z37RepairKindName = obj9.gxTpr_Repairkindname_Z;
         Z35RepairKindRemarks = obj9.gxTpr_Repairkindremarks_Z;
         nIsMod_9 = obj9.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A22RepairId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey067( ) ;
         ScanKeyStart067( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z22RepairId = A22RepairId;
         }
         ZM067( -6) ;
         OnLoadActions067( ) ;
         AddRow067( ) ;
         bcRepair.gxTpr_Kind.ClearCollection();
         if ( RcdFound7 == 1 )
         {
            ScanKeyStart069( ) ;
            nGXsfl_9_idx = 1;
            while ( RcdFound9 != 0 )
            {
               Z22RepairId = A22RepairId;
               Z33RepairKindId = A33RepairKindId;
               ZM069( -11) ;
               OnLoadActions069( ) ;
               nRcdExists_9 = 1;
               nIsMod_9 = 0;
               AddRow069( ) ;
               nGXsfl_9_idx = (int)(nGXsfl_9_idx+1);
               ScanKeyNext069( ) ;
            }
            ScanKeyEnd069( ) ;
         }
         ScanKeyEnd067( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars7( bcRepair, 0) ;
         ScanKeyStart067( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z22RepairId = A22RepairId;
         }
         ZM067( -6) ;
         OnLoadActions067( ) ;
         AddRow067( ) ;
         bcRepair.gxTpr_Kind.ClearCollection();
         if ( RcdFound7 == 1 )
         {
            ScanKeyStart069( ) ;
            nGXsfl_9_idx = 1;
            while ( RcdFound9 != 0 )
            {
               Z22RepairId = A22RepairId;
               Z33RepairKindId = A33RepairKindId;
               ZM069( -11) ;
               OnLoadActions069( ) ;
               nRcdExists_9 = 1;
               nIsMod_9 = 0;
               AddRow069( ) ;
               nGXsfl_9_idx = (int)(nGXsfl_9_idx+1);
               ScanKeyNext069( ) ;
            }
            ScanKeyEnd069( ) ;
         }
         ScanKeyEnd067( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey067( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A36RepairProblems = O36RepairProblems;
            n36RepairProblems = false;
            Insert067( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A22RepairId != Z22RepairId )
               {
                  A22RepairId = Z22RepairId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A36RepairProblems = O36RepairProblems;
                  n36RepairProblems = false;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A36RepairProblems = O36RepairProblems;
                  n36RepairProblems = false;
                  Update067( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A22RepairId != Z22RepairId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        A36RepairProblems = O36RepairProblems;
                        n36RepairProblems = false;
                        Insert067( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        A36RepairProblems = O36RepairProblems;
                        n36RepairProblems = false;
                        Insert067( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars7( bcRepair, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcRepair) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars7( bcRepair, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A36RepairProblems = O36RepairProblems;
         n36RepairProblems = false;
         Insert067( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcRepair) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtRepair auxBC = new SdtRepair(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A22RepairId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcRepair);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars7( bcRepair, 1) ;
         UpdateImpl( ) ;
         VarsToRow7( bcRepair) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars7( bcRepair, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert067( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow7( bcRepair) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars7( bcRepair, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey067( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A22RepairId != Z22RepairId )
            {
               A22RepairId = Z22RepairId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A22RepairId != Z22RepairId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(13);
         context.RollbackDataStores("repair_bc",pr_default);
         VarsToRow7( bcRepair) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcRepair.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcRepair.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcRepair )
         {
            bcRepair = (SdtRepair)(sdt);
            if ( StringUtil.StrCmp(bcRepair.gxTpr_Mode, "") == 0 )
            {
               bcRepair.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcRepair) ;
            }
            else
            {
               RowToVars7( bcRepair, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcRepair.gxTpr_Mode, "") == 0 )
            {
               bcRepair.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcRepair, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtRepair Repair_BC
      {
         get {
            return bcRepair ;
         }

      }

      public override void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected override void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(3);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode7 = "";
         Z23RepairDateFrom = DateTime.MinValue;
         A23RepairDateFrom = DateTime.MinValue;
         Z25RepairDateTo = DateTime.MinValue;
         A25RepairDateTo = DateTime.MinValue;
         Z17GameName = "";
         A17GameName = "";
         Z28TechnicianName = "";
         A28TechnicianName = "";
         Z30RepairAlternateTechnicianName = "";
         A30RepairAlternateTechnicianName = "";
         BC000612_A22RepairId = new short[1] ;
         BC000612_A23RepairDateFrom = new DateTime[] {DateTime.MinValue} ;
         BC000612_A24RepairDaysQuantity = new short[1] ;
         BC000612_A17GameName = new string[] {""} ;
         BC000612_A26RepairCost = new short[1] ;
         BC000612_A28TechnicianName = new string[] {""} ;
         BC000612_A30RepairAlternateTechnicianName = new string[] {""} ;
         BC000612_A31RepairDiscountPercentage = new short[1] ;
         BC000612_A16GameId = new short[1] ;
         BC000612_A27TechnicianId = new short[1] ;
         BC000612_A29RepairAlternateTechnicianId = new short[1] ;
         BC000612_A36RepairProblems = new short[1] ;
         BC000612_n36RepairProblems = new bool[] {false} ;
         BC000610_A36RepairProblems = new short[1] ;
         BC000610_n36RepairProblems = new bool[] {false} ;
         BC00066_A17GameName = new string[] {""} ;
         BC00067_A28TechnicianName = new string[] {""} ;
         BC00068_A30RepairAlternateTechnicianName = new string[] {""} ;
         BC000613_A22RepairId = new short[1] ;
         BC00065_A22RepairId = new short[1] ;
         BC00065_A23RepairDateFrom = new DateTime[] {DateTime.MinValue} ;
         BC00065_A24RepairDaysQuantity = new short[1] ;
         BC00065_A26RepairCost = new short[1] ;
         BC00065_A31RepairDiscountPercentage = new short[1] ;
         BC00065_A16GameId = new short[1] ;
         BC00065_A27TechnicianId = new short[1] ;
         BC00065_A29RepairAlternateTechnicianId = new short[1] ;
         BC00064_A22RepairId = new short[1] ;
         BC00064_A23RepairDateFrom = new DateTime[] {DateTime.MinValue} ;
         BC00064_A24RepairDaysQuantity = new short[1] ;
         BC00064_A26RepairCost = new short[1] ;
         BC00064_A31RepairDiscountPercentage = new short[1] ;
         BC00064_A16GameId = new short[1] ;
         BC00064_A27TechnicianId = new short[1] ;
         BC00064_A29RepairAlternateTechnicianId = new short[1] ;
         BC000614_A22RepairId = new short[1] ;
         BC000618_A36RepairProblems = new short[1] ;
         BC000618_n36RepairProblems = new bool[] {false} ;
         BC000619_A17GameName = new string[] {""} ;
         BC000620_A28TechnicianName = new string[] {""} ;
         BC000621_A30RepairAlternateTechnicianName = new string[] {""} ;
         BC000623_A22RepairId = new short[1] ;
         BC000623_A23RepairDateFrom = new DateTime[] {DateTime.MinValue} ;
         BC000623_A24RepairDaysQuantity = new short[1] ;
         BC000623_A17GameName = new string[] {""} ;
         BC000623_A26RepairCost = new short[1] ;
         BC000623_A28TechnicianName = new string[] {""} ;
         BC000623_A30RepairAlternateTechnicianName = new string[] {""} ;
         BC000623_A31RepairDiscountPercentage = new short[1] ;
         BC000623_A16GameId = new short[1] ;
         BC000623_A27TechnicianId = new short[1] ;
         BC000623_A29RepairAlternateTechnicianId = new short[1] ;
         BC000623_A36RepairProblems = new short[1] ;
         BC000623_n36RepairProblems = new bool[] {false} ;
         Z37RepairKindName = "";
         A37RepairKindName = "";
         Z35RepairKindRemarks = "";
         A35RepairKindRemarks = "";
         BC000624_A22RepairId = new short[1] ;
         BC000624_A33RepairKindId = new short[1] ;
         BC000624_A37RepairKindName = new string[] {""} ;
         BC000624_A35RepairKindRemarks = new string[] {""} ;
         BC000625_A22RepairId = new short[1] ;
         BC000625_A33RepairKindId = new short[1] ;
         BC00063_A22RepairId = new short[1] ;
         BC00063_A33RepairKindId = new short[1] ;
         BC00063_A37RepairKindName = new string[] {""} ;
         BC00063_A35RepairKindRemarks = new string[] {""} ;
         sMode9 = "";
         BC00062_A22RepairId = new short[1] ;
         BC00062_A33RepairKindId = new short[1] ;
         BC00062_A37RepairKindName = new string[] {""} ;
         BC00062_A35RepairKindRemarks = new string[] {""} ;
         BC000629_A22RepairId = new short[1] ;
         BC000629_A33RepairKindId = new short[1] ;
         BC000629_A37RepairKindName = new string[] {""} ;
         BC000629_A35RepairKindRemarks = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.repair_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A22RepairId, BC00062_A33RepairKindId, BC00062_A37RepairKindName, BC00062_A35RepairKindRemarks
               }
               , new Object[] {
               BC00063_A22RepairId, BC00063_A33RepairKindId, BC00063_A37RepairKindName, BC00063_A35RepairKindRemarks
               }
               , new Object[] {
               BC00064_A22RepairId, BC00064_A23RepairDateFrom, BC00064_A24RepairDaysQuantity, BC00064_A26RepairCost, BC00064_A31RepairDiscountPercentage, BC00064_A16GameId, BC00064_A27TechnicianId, BC00064_A29RepairAlternateTechnicianId
               }
               , new Object[] {
               BC00065_A22RepairId, BC00065_A23RepairDateFrom, BC00065_A24RepairDaysQuantity, BC00065_A26RepairCost, BC00065_A31RepairDiscountPercentage, BC00065_A16GameId, BC00065_A27TechnicianId, BC00065_A29RepairAlternateTechnicianId
               }
               , new Object[] {
               BC00066_A17GameName
               }
               , new Object[] {
               BC00067_A28TechnicianName
               }
               , new Object[] {
               BC00068_A30RepairAlternateTechnicianName
               }
               , new Object[] {
               BC000610_A36RepairProblems, BC000610_n36RepairProblems
               }
               , new Object[] {
               BC000612_A22RepairId, BC000612_A23RepairDateFrom, BC000612_A24RepairDaysQuantity, BC000612_A17GameName, BC000612_A26RepairCost, BC000612_A28TechnicianName, BC000612_A30RepairAlternateTechnicianName, BC000612_A31RepairDiscountPercentage, BC000612_A16GameId, BC000612_A27TechnicianId,
               BC000612_A29RepairAlternateTechnicianId, BC000612_A36RepairProblems, BC000612_n36RepairProblems
               }
               , new Object[] {
               BC000613_A22RepairId
               }
               , new Object[] {
               BC000614_A22RepairId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000618_A36RepairProblems, BC000618_n36RepairProblems
               }
               , new Object[] {
               BC000619_A17GameName
               }
               , new Object[] {
               BC000620_A28TechnicianName
               }
               , new Object[] {
               BC000621_A30RepairAlternateTechnicianName
               }
               , new Object[] {
               BC000623_A22RepairId, BC000623_A23RepairDateFrom, BC000623_A24RepairDaysQuantity, BC000623_A17GameName, BC000623_A26RepairCost, BC000623_A28TechnicianName, BC000623_A30RepairAlternateTechnicianName, BC000623_A31RepairDiscountPercentage, BC000623_A16GameId, BC000623_A27TechnicianId,
               BC000623_A29RepairAlternateTechnicianId, BC000623_A36RepairProblems, BC000623_n36RepairProblems
               }
               , new Object[] {
               BC000624_A22RepairId, BC000624_A33RepairKindId, BC000624_A37RepairKindName, BC000624_A35RepairKindRemarks
               }
               , new Object[] {
               BC000625_A22RepairId, BC000625_A33RepairKindId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000629_A22RepairId, BC000629_A33RepairKindId, BC000629_A37RepairKindName, BC000629_A35RepairKindRemarks
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z22RepairId ;
      private short A22RepairId ;
      private short s36RepairProblems ;
      private short O36RepairProblems ;
      private short A36RepairProblems ;
      private short nIsMod_9 ;
      private short RcdFound9 ;
      private short GX_JID ;
      private short Z24RepairDaysQuantity ;
      private short A24RepairDaysQuantity ;
      private short Z26RepairCost ;
      private short A26RepairCost ;
      private short Z31RepairDiscountPercentage ;
      private short A31RepairDiscountPercentage ;
      private short Z16GameId ;
      private short A16GameId ;
      private short Z27TechnicianId ;
      private short A27TechnicianId ;
      private short Z29RepairAlternateTechnicianId ;
      private short A29RepairAlternateTechnicianId ;
      private short Z32RepairFinalCost ;
      private short A32RepairFinalCost ;
      private short Z36RepairProblems ;
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private short nRcdExists_9 ;
      private short Gxremove9 ;
      private short Z33RepairKindId ;
      private short A33RepairKindId ;
      private short nIsDirty_9 ;
      private short Gx_BScreen ;
      private int trnEnded ;
      private int nGXsfl_9_idx=1 ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode7 ;
      private string Z17GameName ;
      private string A17GameName ;
      private string Z28TechnicianName ;
      private string A28TechnicianName ;
      private string Z30RepairAlternateTechnicianName ;
      private string A30RepairAlternateTechnicianName ;
      private string Z37RepairKindName ;
      private string A37RepairKindName ;
      private string Z35RepairKindRemarks ;
      private string A35RepairKindRemarks ;
      private string sMode9 ;
      private DateTime Z23RepairDateFrom ;
      private DateTime A23RepairDateFrom ;
      private DateTime Z25RepairDateTo ;
      private DateTime A25RepairDateTo ;
      private bool n36RepairProblems ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private SdtRepair bcRepair ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000612_A22RepairId ;
      private DateTime[] BC000612_A23RepairDateFrom ;
      private short[] BC000612_A24RepairDaysQuantity ;
      private string[] BC000612_A17GameName ;
      private short[] BC000612_A26RepairCost ;
      private string[] BC000612_A28TechnicianName ;
      private string[] BC000612_A30RepairAlternateTechnicianName ;
      private short[] BC000612_A31RepairDiscountPercentage ;
      private short[] BC000612_A16GameId ;
      private short[] BC000612_A27TechnicianId ;
      private short[] BC000612_A29RepairAlternateTechnicianId ;
      private short[] BC000612_A36RepairProblems ;
      private bool[] BC000612_n36RepairProblems ;
      private short[] BC000610_A36RepairProblems ;
      private bool[] BC000610_n36RepairProblems ;
      private string[] BC00066_A17GameName ;
      private string[] BC00067_A28TechnicianName ;
      private string[] BC00068_A30RepairAlternateTechnicianName ;
      private short[] BC000613_A22RepairId ;
      private short[] BC00065_A22RepairId ;
      private DateTime[] BC00065_A23RepairDateFrom ;
      private short[] BC00065_A24RepairDaysQuantity ;
      private short[] BC00065_A26RepairCost ;
      private short[] BC00065_A31RepairDiscountPercentage ;
      private short[] BC00065_A16GameId ;
      private short[] BC00065_A27TechnicianId ;
      private short[] BC00065_A29RepairAlternateTechnicianId ;
      private short[] BC00064_A22RepairId ;
      private DateTime[] BC00064_A23RepairDateFrom ;
      private short[] BC00064_A24RepairDaysQuantity ;
      private short[] BC00064_A26RepairCost ;
      private short[] BC00064_A31RepairDiscountPercentage ;
      private short[] BC00064_A16GameId ;
      private short[] BC00064_A27TechnicianId ;
      private short[] BC00064_A29RepairAlternateTechnicianId ;
      private short[] BC000614_A22RepairId ;
      private short[] BC000618_A36RepairProblems ;
      private bool[] BC000618_n36RepairProblems ;
      private string[] BC000619_A17GameName ;
      private string[] BC000620_A28TechnicianName ;
      private string[] BC000621_A30RepairAlternateTechnicianName ;
      private short[] BC000623_A22RepairId ;
      private DateTime[] BC000623_A23RepairDateFrom ;
      private short[] BC000623_A24RepairDaysQuantity ;
      private string[] BC000623_A17GameName ;
      private short[] BC000623_A26RepairCost ;
      private string[] BC000623_A28TechnicianName ;
      private string[] BC000623_A30RepairAlternateTechnicianName ;
      private short[] BC000623_A31RepairDiscountPercentage ;
      private short[] BC000623_A16GameId ;
      private short[] BC000623_A27TechnicianId ;
      private short[] BC000623_A29RepairAlternateTechnicianId ;
      private short[] BC000623_A36RepairProblems ;
      private bool[] BC000623_n36RepairProblems ;
      private short[] BC000624_A22RepairId ;
      private short[] BC000624_A33RepairKindId ;
      private string[] BC000624_A37RepairKindName ;
      private string[] BC000624_A35RepairKindRemarks ;
      private short[] BC000625_A22RepairId ;
      private short[] BC000625_A33RepairKindId ;
      private short[] BC00063_A22RepairId ;
      private short[] BC00063_A33RepairKindId ;
      private string[] BC00063_A37RepairKindName ;
      private string[] BC00063_A35RepairKindRemarks ;
      private short[] BC00062_A22RepairId ;
      private short[] BC00062_A33RepairKindId ;
      private string[] BC00062_A37RepairKindName ;
      private string[] BC00062_A35RepairKindRemarks ;
      private short[] BC000629_A22RepairId ;
      private short[] BC000629_A33RepairKindId ;
      private string[] BC000629_A37RepairKindName ;
      private string[] BC000629_A35RepairKindRemarks ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class repair_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000612;
          prmBC000612 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC000610;
          prmBC000610 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC00066;
          prmBC00066 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmBC00067;
          prmBC00067 = new Object[] {
          new ParDef("@TechnicianId",GXType.Int16,4,0)
          };
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0)
          };
          Object[] prmBC000613;
          prmBC000613 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC00065;
          prmBC00065 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC000614;
          prmBC000614 = new Object[] {
          new ParDef("@RepairDateFrom",GXType.Date,8,0) ,
          new ParDef("@RepairDaysQuantity",GXType.Int16,4,0) ,
          new ParDef("@RepairCost",GXType.Int16,4,0) ,
          new ParDef("@RepairDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@GameId",GXType.Int16,4,0) ,
          new ParDef("@TechnicianId",GXType.Int16,4,0) ,
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0)
          };
          Object[] prmBC000615;
          prmBC000615 = new Object[] {
          new ParDef("@RepairDateFrom",GXType.Date,8,0) ,
          new ParDef("@RepairDaysQuantity",GXType.Int16,4,0) ,
          new ParDef("@RepairCost",GXType.Int16,4,0) ,
          new ParDef("@RepairDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@GameId",GXType.Int16,4,0) ,
          new ParDef("@TechnicianId",GXType.Int16,4,0) ,
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0) ,
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC000616;
          prmBC000616 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC000618;
          prmBC000618 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC000619;
          prmBC000619 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmBC000620;
          prmBC000620 = new Object[] {
          new ParDef("@TechnicianId",GXType.Int16,4,0)
          };
          Object[] prmBC000621;
          prmBC000621 = new Object[] {
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0)
          };
          Object[] prmBC000623;
          prmBC000623 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmBC000624;
          prmBC000624 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmBC000625;
          prmBC000625 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmBC000626;
          prmBC000626 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0) ,
          new ParDef("@RepairKindName",GXType.NChar,1,0) ,
          new ParDef("@RepairKindRemarks",GXType.NChar,120,0)
          };
          Object[] prmBC000627;
          prmBC000627 = new Object[] {
          new ParDef("@RepairKindName",GXType.NChar,1,0) ,
          new ParDef("@RepairKindRemarks",GXType.NChar,120,0) ,
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmBC000628;
          prmBC000628 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmBC000629;
          prmBC000629 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks] FROM [RepairRepairTransaction] WITH (UPDLOCK) WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks] FROM [RepairRepairTransaction] WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT [RepairId], [RepairDateFrom], [RepairDaysQuantity], [RepairCost], [RepairDiscountPercentage], [GameId], [TechnicianId], [RepairAlternateTechnicianId] AS RepairAlternateTechnicianId FROM [Repair] WITH (UPDLOCK) WHERE [RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00065", "SELECT [RepairId], [RepairDateFrom], [RepairDaysQuantity], [RepairCost], [RepairDiscountPercentage], [GameId], [TechnicianId], [RepairAlternateTechnicianId] AS RepairAlternateTechnicianId FROM [Repair] WHERE [RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00066", "SELECT [GameName] FROM [Game] WHERE [GameId] = @GameId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00067", "SELECT [TechnicianName] FROM [Technician] WHERE [TechnicianId] = @TechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00068", "SELECT [TechnicianName] AS RepairAlternateTechnicianName FROM [Technician] WHERE [TechnicianId] = @RepairAlternateTechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000610", "SELECT COALESCE( T1.[RepairProblems], 0) AS RepairProblems FROM (SELECT COUNT(*) AS RepairProblems, [RepairId] FROM [RepairRepairTransaction] WITH (UPDLOCK) GROUP BY [RepairId] ) T1 WHERE T1.[RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000612", "SELECT TM1.[RepairId], TM1.[RepairDateFrom], TM1.[RepairDaysQuantity], T3.[GameName], TM1.[RepairCost], T4.[TechnicianName], T5.[TechnicianName] AS RepairAlternateTechnicianName, TM1.[RepairDiscountPercentage], TM1.[GameId], TM1.[TechnicianId], TM1.[RepairAlternateTechnicianId] AS RepairAlternateTechnicianId, COALESCE( T2.[RepairProblems], 0) AS RepairProblems FROM (((([Repair] TM1 LEFT JOIN (SELECT COUNT(*) AS RepairProblems, [RepairId] FROM [RepairRepairTransaction] GROUP BY [RepairId] ) T2 ON T2.[RepairId] = TM1.[RepairId]) INNER JOIN [Game] T3 ON T3.[GameId] = TM1.[GameId]) INNER JOIN [Technician] T4 ON T4.[TechnicianId] = TM1.[TechnicianId]) INNER JOIN [Technician] T5 ON T5.[TechnicianId] = TM1.[RepairAlternateTechnicianId]) WHERE TM1.[RepairId] = @RepairId ORDER BY TM1.[RepairId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000613", "SELECT [RepairId] FROM [Repair] WHERE [RepairId] = @RepairId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000614", "INSERT INTO [Repair]([RepairDateFrom], [RepairDaysQuantity], [RepairCost], [RepairDiscountPercentage], [GameId], [TechnicianId], [RepairAlternateTechnicianId]) VALUES(@RepairDateFrom, @RepairDaysQuantity, @RepairCost, @RepairDiscountPercentage, @GameId, @TechnicianId, @RepairAlternateTechnicianId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmBC000614)
             ,new CursorDef("BC000615", "UPDATE [Repair] SET [RepairDateFrom]=@RepairDateFrom, [RepairDaysQuantity]=@RepairDaysQuantity, [RepairCost]=@RepairCost, [RepairDiscountPercentage]=@RepairDiscountPercentage, [GameId]=@GameId, [TechnicianId]=@TechnicianId, [RepairAlternateTechnicianId]=@RepairAlternateTechnicianId  WHERE [RepairId] = @RepairId", GxErrorMask.GX_NOMASK,prmBC000615)
             ,new CursorDef("BC000616", "DELETE FROM [Repair]  WHERE [RepairId] = @RepairId", GxErrorMask.GX_NOMASK,prmBC000616)
             ,new CursorDef("BC000618", "SELECT COALESCE( T1.[RepairProblems], 0) AS RepairProblems FROM (SELECT COUNT(*) AS RepairProblems, [RepairId] FROM [RepairRepairTransaction] WITH (UPDLOCK) GROUP BY [RepairId] ) T1 WHERE T1.[RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000619", "SELECT [GameName] FROM [Game] WHERE [GameId] = @GameId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000619,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000620", "SELECT [TechnicianName] FROM [Technician] WHERE [TechnicianId] = @TechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000620,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000621", "SELECT [TechnicianName] AS RepairAlternateTechnicianName FROM [Technician] WHERE [TechnicianId] = @RepairAlternateTechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000621,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000623", "SELECT TM1.[RepairId], TM1.[RepairDateFrom], TM1.[RepairDaysQuantity], T3.[GameName], TM1.[RepairCost], T4.[TechnicianName], T5.[TechnicianName] AS RepairAlternateTechnicianName, TM1.[RepairDiscountPercentage], TM1.[GameId], TM1.[TechnicianId], TM1.[RepairAlternateTechnicianId] AS RepairAlternateTechnicianId, COALESCE( T2.[RepairProblems], 0) AS RepairProblems FROM (((([Repair] TM1 LEFT JOIN (SELECT COUNT(*) AS RepairProblems, [RepairId] FROM [RepairRepairTransaction] GROUP BY [RepairId] ) T2 ON T2.[RepairId] = TM1.[RepairId]) INNER JOIN [Game] T3 ON T3.[GameId] = TM1.[GameId]) INNER JOIN [Technician] T4 ON T4.[TechnicianId] = TM1.[TechnicianId]) INNER JOIN [Technician] T5 ON T5.[TechnicianId] = TM1.[RepairAlternateTechnicianId]) WHERE TM1.[RepairId] = @RepairId ORDER BY TM1.[RepairId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000623,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000624", "SELECT [RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks] FROM [RepairRepairTransaction] WHERE [RepairId] = @RepairId and [RepairKindId] = @RepairKindId ORDER BY [RepairId], [RepairKindId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000624,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000625", "SELECT [RepairId], [RepairKindId] FROM [RepairRepairTransaction] WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000626", "INSERT INTO [RepairRepairTransaction]([RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks]) VALUES(@RepairId, @RepairKindId, @RepairKindName, @RepairKindRemarks)", GxErrorMask.GX_NOMASK,prmBC000626)
             ,new CursorDef("BC000627", "UPDATE [RepairRepairTransaction] SET [RepairKindName]=@RepairKindName, [RepairKindRemarks]=@RepairKindRemarks  WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId", GxErrorMask.GX_NOMASK,prmBC000627)
             ,new CursorDef("BC000628", "DELETE FROM [RepairRepairTransaction]  WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId", GxErrorMask.GX_NOMASK,prmBC000628)
             ,new CursorDef("BC000629", "SELECT [RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks] FROM [RepairRepairTransaction] WHERE [RepairId] = @RepairId ORDER BY [RepairId], [RepairKindId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000629,11, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 50);
                ((string[]) buf[6])[0] = rslt.getString(7, 50);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((short[]) buf[9])[0] = rslt.getShort(10);
                ((short[]) buf[10])[0] = rslt.getShort(11);
                ((short[]) buf[11])[0] = rslt.getShort(12);
                ((bool[]) buf[12])[0] = rslt.wasNull(12);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
       }
    }

 }

}
