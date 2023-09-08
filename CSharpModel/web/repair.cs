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
   public class repair : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetNextPar( );
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A22RepairId = (short)(NumberUtil.Val( GetPar( "RepairId"), "."));
            AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A22RepairId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A16GameId = (short)(NumberUtil.Val( GetPar( "GameId"), "."));
            AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A16GameId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A27TechnicianId = (short)(NumberUtil.Val( GetPar( "TechnicianId"), "."));
            AssignAttri("", false, "A27TechnicianId", StringUtil.LTrimStr( (decimal)(A27TechnicianId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A27TechnicianId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A29RepairAlternateTechnicianId = (short)(NumberUtil.Val( GetPar( "RepairAlternateTechnicianId"), "."));
            AssignAttri("", false, "A29RepairAlternateTechnicianId", StringUtil.LTrimStr( (decimal)(A29RepairAlternateTechnicianId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A29RepairAlternateTechnicianId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridrepair_kind") == 0 )
         {
            nRC_GXsfl_108 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_108"), "."));
            nGXsfl_108_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_108_idx"), "."));
            sGXsfl_108_idx = GetPar( "sGXsfl_108_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridrepair_kind_newrow( ) ;
            return  ;
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "Repair", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtRepairId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("Carmine");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public repair( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public repair( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbRepairKindName = new GXCombobox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("rwdmasterpage", "GeneXus.Programs.rwdmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "WWAdvancedContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "TableTop", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Repair", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8 col-sm-offset-2", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 ToolbarCellClass", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 4, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "gx.popup.openPrompt('"+"gx0070.aspx"+"',["+"{Ctrl:gx.dom.el('"+"REPAIRID"+"'), id:'"+"REPAIRID"+"'"+",IOType:'out',isKey:true,isLastKey:true}"+"],"+"null"+","+"'', false"+","+"true"+");"+"return false;", 2, "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCellAdvanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepairId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22RepairId), 4, 0, ".", "")), StringUtil.LTrim( ((edtRepairId_Enabled!=0) ? context.localUtil.Format( (decimal)(A22RepairId), "ZZZ9") : context.localUtil.Format( (decimal)(A22RepairId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairDateFrom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairDateFrom_Internalname, "Date From", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtRepairDateFrom_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtRepairDateFrom_Internalname, context.localUtil.Format(A23RepairDateFrom, "99/99/99"), context.localUtil.Format( A23RepairDateFrom, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairDateFrom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairDateFrom_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         GxWebStd.gx_bitmap( context, edtRepairDateFrom_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtRepairDateFrom_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Repair.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairDaysQuantity_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairDaysQuantity_Internalname, "Days Quantity", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepairDaysQuantity_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RepairDaysQuantity), 4, 0, ".", "")), StringUtil.LTrim( ((edtRepairDaysQuantity_Enabled!=0) ? context.localUtil.Format( (decimal)(A24RepairDaysQuantity), "ZZZ9") : context.localUtil.Format( (decimal)(A24RepairDaysQuantity), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairDaysQuantity_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairDaysQuantity_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairDateTo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairDateTo_Internalname, "Date To", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtRepairDateTo_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtRepairDateTo_Internalname, context.localUtil.Format(A25RepairDateTo, "99/99/99"), context.localUtil.Format( A25RepairDateTo, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairDateTo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairDateTo_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         GxWebStd.gx_bitmap( context, edtRepairDateTo_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtRepairDateTo_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Repair.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGameId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGameId_Internalname, "Game Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGameId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16GameId), 4, 0, ".", "")), StringUtil.LTrim( ((edtGameId_Enabled!=0) ? context.localUtil.Format( (decimal)(A16GameId), "ZZZ9") : context.localUtil.Format( (decimal)(A16GameId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGameId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGameId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_16_Internalname, sImgUrl, imgprompt_16_Link, "", "", context.GetTheme( ), imgprompt_16_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtGameName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGameName_Internalname, "Game Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtGameName_Internalname, StringUtil.RTrim( A17GameName), StringUtil.RTrim( context.localUtil.Format( A17GameName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGameName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtGameName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairCost_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairCost_Internalname, "Cost", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepairCost_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26RepairCost), 4, 0, ".", "")), StringUtil.LTrim( ((edtRepairCost_Enabled!=0) ? context.localUtil.Format( (decimal)(A26RepairCost), "ZZZ9") : context.localUtil.Format( (decimal)(A26RepairCost), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairCost_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairCost_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTechnicianId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTechnicianId_Internalname, "Technician Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTechnicianId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A27TechnicianId), 4, 0, ".", "")), StringUtil.LTrim( ((edtTechnicianId_Enabled!=0) ? context.localUtil.Format( (decimal)(A27TechnicianId), "ZZZ9") : context.localUtil.Format( (decimal)(A27TechnicianId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTechnicianId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTechnicianId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_27_Internalname, sImgUrl, imgprompt_27_Link, "", "", context.GetTheme( ), imgprompt_27_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTechnicianName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTechnicianName_Internalname, "Technician Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTechnicianName_Internalname, StringUtil.RTrim( A28TechnicianName), StringUtil.RTrim( context.localUtil.Format( A28TechnicianName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTechnicianName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTechnicianName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairAlternateTechnicianId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairAlternateTechnicianId_Internalname, "Technician Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepairAlternateTechnicianId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A29RepairAlternateTechnicianId), 4, 0, ".", "")), StringUtil.LTrim( ((edtRepairAlternateTechnicianId_Enabled!=0) ? context.localUtil.Format( (decimal)(A29RepairAlternateTechnicianId), "ZZZ9") : context.localUtil.Format( (decimal)(A29RepairAlternateTechnicianId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairAlternateTechnicianId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairAlternateTechnicianId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image";
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_29_Internalname, sImgUrl, imgprompt_29_Link, "", "", context.GetTheme( ), imgprompt_29_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairAlternateTechnicianName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairAlternateTechnicianName_Internalname, "Technician Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtRepairAlternateTechnicianName_Internalname, StringUtil.RTrim( A30RepairAlternateTechnicianName), StringUtil.RTrim( context.localUtil.Format( A30RepairAlternateTechnicianName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairAlternateTechnicianName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairAlternateTechnicianName_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "Name", "left", true, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairDiscountPercentage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairDiscountPercentage_Internalname, "Discount Percentage", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRepairDiscountPercentage_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A31RepairDiscountPercentage), 3, 0, ".", "")), StringUtil.LTrim( ((edtRepairDiscountPercentage_Enabled!=0) ? context.localUtil.Format( (decimal)(A31RepairDiscountPercentage), "ZZ9") : context.localUtil.Format( (decimal)(A31RepairDiscountPercentage), "ZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairDiscountPercentage_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairDiscountPercentage_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, 0, true, "Percentage", "right", false, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairFinalCost_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairFinalCost_Internalname, "Final Cost", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtRepairFinalCost_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32RepairFinalCost), 4, 0, ".", "")), StringUtil.LTrim( ((edtRepairFinalCost_Enabled!=0) ? context.localUtil.Format( (decimal)(A32RepairFinalCost), "ZZZ9") : context.localUtil.Format( (decimal)(A32RepairFinalCost), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairFinalCost_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairFinalCost_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtRepairProblems_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtRepairProblems_Internalname, "Problems", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtRepairProblems_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A36RepairProblems), 1, 0, ".", "")), StringUtil.LTrim( ((edtRepairProblems_Enabled!=0) ? context.localUtil.Format( (decimal)(A36RepairProblems), "9") : context.localUtil.Format( (decimal)(A36RepairProblems), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRepairProblems_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRepairProblems_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divKindtable_Internalname, 1, 0, "px", 0, "px", "LevelTable", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 FormCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlekind_Internalname, "Kind", "", "", lblTitlekind_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridrepair_kind( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirm", bttBtn_enter_Jsonclick, 5, "Confirm", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Repair.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Center", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridrepair_kind( )
      {
         /*  Grid Control  */
         Gridrepair_kindContainer.AddObjectProperty("GridName", "Gridrepair_kind");
         Gridrepair_kindContainer.AddObjectProperty("Header", subGridrepair_kind_Header);
         Gridrepair_kindContainer.AddObjectProperty("Class", "Grid");
         Gridrepair_kindContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrepair_kind_Backcolorstyle), 1, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("CmpContext", "");
         Gridrepair_kindContainer.AddObjectProperty("InMasterPage", "false");
         Gridrepair_kindColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridrepair_kindColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A33RepairKindId), 1, 0, ".", "")));
         Gridrepair_kindColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRepairKindId_Enabled), 5, 0, ".", "")));
         Gridrepair_kindContainer.AddColumnProperties(Gridrepair_kindColumn);
         Gridrepair_kindColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridrepair_kindColumn.AddObjectProperty("Value", StringUtil.RTrim( A37RepairKindName));
         Gridrepair_kindColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRepairKindName.Enabled), 5, 0, ".", "")));
         Gridrepair_kindContainer.AddColumnProperties(Gridrepair_kindColumn);
         Gridrepair_kindColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridrepair_kindColumn.AddObjectProperty("Value", StringUtil.RTrim( A35RepairKindRemarks));
         Gridrepair_kindColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRepairKindRemarks_Enabled), 5, 0, ".", "")));
         Gridrepair_kindContainer.AddColumnProperties(Gridrepair_kindColumn);
         Gridrepair_kindContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrepair_kind_Selectedindex), 4, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrepair_kind_Allowselection), 1, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrepair_kind_Selectioncolor), 9, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrepair_kind_Allowhovering), 1, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrepair_kind_Hoveringcolor), 9, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrepair_kind_Allowcollapsing), 1, 0, ".", "")));
         Gridrepair_kindContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridrepair_kind_Collapsed), 1, 0, ".", "")));
         nGXsfl_108_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount9 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_9 = 1;
               ScanStart069( ) ;
               while ( RcdFound9 != 0 )
               {
                  init_level_properties9( ) ;
                  getByPrimaryKey069( ) ;
                  AddRow069( ) ;
                  ScanNext069( ) ;
               }
               ScanEnd069( ) ;
               nBlankRcdCount9 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B36RepairProblems = A36RepairProblems;
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            standaloneNotModal069( ) ;
            standaloneModal069( ) ;
            sMode9 = Gx_mode;
            while ( nGXsfl_108_idx < nRC_GXsfl_108 )
            {
               bGXsfl_108_Refreshing = true;
               ReadRow069( ) ;
               edtRepairKindId_Enabled = (int)(context.localUtil.CToN( cgiGet( "REPAIRKINDID_"+sGXsfl_108_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtRepairKindId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairKindId_Enabled), 5, 0), !bGXsfl_108_Refreshing);
               cmbRepairKindName.Enabled = (int)(context.localUtil.CToN( cgiGet( "REPAIRKINDNAME_"+sGXsfl_108_idx+"Enabled"), ".", ","));
               AssignProp("", false, cmbRepairKindName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRepairKindName.Enabled), 5, 0), !bGXsfl_108_Refreshing);
               edtRepairKindRemarks_Enabled = (int)(context.localUtil.CToN( cgiGet( "REPAIRKINDREMARKS_"+sGXsfl_108_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtRepairKindRemarks_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairKindRemarks_Enabled), 5, 0), !bGXsfl_108_Refreshing);
               if ( ( nRcdExists_9 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal069( ) ;
               }
               SendRow069( ) ;
               bGXsfl_108_Refreshing = false;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A36RepairProblems = B36RepairProblems;
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount9 = 5;
            nRcdExists_9 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart069( ) ;
               while ( RcdFound9 != 0 )
               {
                  sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_1089( ) ;
                  init_level_properties9( ) ;
                  standaloneNotModal069( ) ;
                  getByPrimaryKey069( ) ;
                  standaloneModal069( ) ;
                  AddRow069( ) ;
                  ScanNext069( ) ;
               }
               ScanEnd069( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode9 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx+1), 4, 0), 4, "0");
         SubsflControlProps_1089( ) ;
         InitAll069( ) ;
         init_level_properties9( ) ;
         B36RepairProblems = A36RepairProblems;
         n36RepairProblems = false;
         AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         nRcdDeleted_9 = 0;
         nBlankRcdCount9 = (short)(nBlankRcdUsr9+nBlankRcdCount9);
         fRowAdded = 0;
         while ( nBlankRcdCount9 > 0 )
         {
            standaloneNotModal069( ) ;
            standaloneModal069( ) ;
            AddRow069( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtRepairKindId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount9 = (short)(nBlankRcdCount9-1);
         }
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         A36RepairProblems = B36RepairProblems;
         n36RepairProblems = false;
         AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridrepair_kindContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridrepair_kind", Gridrepair_kindContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridrepair_kindContainerData", Gridrepair_kindContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridrepair_kindContainerData"+"V", Gridrepair_kindContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridrepair_kindContainerData"+"V"+"\" value='"+Gridrepair_kindContainer.GridValuesHidden()+"'/>") ;
         }
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z22RepairId = (short)(context.localUtil.CToN( cgiGet( "Z22RepairId"), ".", ","));
            Z23RepairDateFrom = context.localUtil.CToD( cgiGet( "Z23RepairDateFrom"), 0);
            Z24RepairDaysQuantity = (short)(context.localUtil.CToN( cgiGet( "Z24RepairDaysQuantity"), ".", ","));
            Z26RepairCost = (short)(context.localUtil.CToN( cgiGet( "Z26RepairCost"), ".", ","));
            Z31RepairDiscountPercentage = (short)(context.localUtil.CToN( cgiGet( "Z31RepairDiscountPercentage"), ".", ","));
            Z16GameId = (short)(context.localUtil.CToN( cgiGet( "Z16GameId"), ".", ","));
            Z27TechnicianId = (short)(context.localUtil.CToN( cgiGet( "Z27TechnicianId"), ".", ","));
            Z29RepairAlternateTechnicianId = (short)(context.localUtil.CToN( cgiGet( "Z29RepairAlternateTechnicianId"), ".", ","));
            O36RepairProblems = (short)(context.localUtil.CToN( cgiGet( "O36RepairProblems"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_108 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_108"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtRepairId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepairId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPAIRID");
               AnyError = 1;
               GX_FocusControl = edtRepairId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22RepairId = 0;
               AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
            }
            else
            {
               A22RepairId = (short)(context.localUtil.CToN( cgiGet( edtRepairId_Internalname), ".", ","));
               AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtRepairDateFrom_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Repair Date From"}), 1, "REPAIRDATEFROM");
               AnyError = 1;
               GX_FocusControl = edtRepairDateFrom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A23RepairDateFrom = DateTime.MinValue;
               AssignAttri("", false, "A23RepairDateFrom", context.localUtil.Format(A23RepairDateFrom, "99/99/99"));
            }
            else
            {
               A23RepairDateFrom = context.localUtil.CToD( cgiGet( edtRepairDateFrom_Internalname), 1);
               AssignAttri("", false, "A23RepairDateFrom", context.localUtil.Format(A23RepairDateFrom, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtRepairDaysQuantity_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepairDaysQuantity_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPAIRDAYSQUANTITY");
               AnyError = 1;
               GX_FocusControl = edtRepairDaysQuantity_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A24RepairDaysQuantity = 0;
               AssignAttri("", false, "A24RepairDaysQuantity", StringUtil.LTrimStr( (decimal)(A24RepairDaysQuantity), 4, 0));
            }
            else
            {
               A24RepairDaysQuantity = (short)(context.localUtil.CToN( cgiGet( edtRepairDaysQuantity_Internalname), ".", ","));
               AssignAttri("", false, "A24RepairDaysQuantity", StringUtil.LTrimStr( (decimal)(A24RepairDaysQuantity), 4, 0));
            }
            A25RepairDateTo = context.localUtil.CToD( cgiGet( edtRepairDateTo_Internalname), 1);
            AssignAttri("", false, "A25RepairDateTo", context.localUtil.Format(A25RepairDateTo, "99/99/99"));
            if ( ( ( context.localUtil.CToN( cgiGet( edtGameId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtGameId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "GAMEID");
               AnyError = 1;
               GX_FocusControl = edtGameId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A16GameId = 0;
               AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            }
            else
            {
               A16GameId = (short)(context.localUtil.CToN( cgiGet( edtGameId_Internalname), ".", ","));
               AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            }
            A17GameName = cgiGet( edtGameName_Internalname);
            AssignAttri("", false, "A17GameName", A17GameName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRepairCost_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepairCost_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPAIRCOST");
               AnyError = 1;
               GX_FocusControl = edtRepairCost_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A26RepairCost = 0;
               AssignAttri("", false, "A26RepairCost", StringUtil.LTrimStr( (decimal)(A26RepairCost), 4, 0));
            }
            else
            {
               A26RepairCost = (short)(context.localUtil.CToN( cgiGet( edtRepairCost_Internalname), ".", ","));
               AssignAttri("", false, "A26RepairCost", StringUtil.LTrimStr( (decimal)(A26RepairCost), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTechnicianId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTechnicianId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TECHNICIANID");
               AnyError = 1;
               GX_FocusControl = edtTechnicianId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A27TechnicianId = 0;
               AssignAttri("", false, "A27TechnicianId", StringUtil.LTrimStr( (decimal)(A27TechnicianId), 4, 0));
            }
            else
            {
               A27TechnicianId = (short)(context.localUtil.CToN( cgiGet( edtTechnicianId_Internalname), ".", ","));
               AssignAttri("", false, "A27TechnicianId", StringUtil.LTrimStr( (decimal)(A27TechnicianId), 4, 0));
            }
            A28TechnicianName = cgiGet( edtTechnicianName_Internalname);
            AssignAttri("", false, "A28TechnicianName", A28TechnicianName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRepairAlternateTechnicianId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepairAlternateTechnicianId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPAIRALTERNATETECHNICIANID");
               AnyError = 1;
               GX_FocusControl = edtRepairAlternateTechnicianId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A29RepairAlternateTechnicianId = 0;
               AssignAttri("", false, "A29RepairAlternateTechnicianId", StringUtil.LTrimStr( (decimal)(A29RepairAlternateTechnicianId), 4, 0));
            }
            else
            {
               A29RepairAlternateTechnicianId = (short)(context.localUtil.CToN( cgiGet( edtRepairAlternateTechnicianId_Internalname), ".", ","));
               AssignAttri("", false, "A29RepairAlternateTechnicianId", StringUtil.LTrimStr( (decimal)(A29RepairAlternateTechnicianId), 4, 0));
            }
            A30RepairAlternateTechnicianName = cgiGet( edtRepairAlternateTechnicianName_Internalname);
            AssignAttri("", false, "A30RepairAlternateTechnicianName", A30RepairAlternateTechnicianName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtRepairDiscountPercentage_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepairDiscountPercentage_Internalname), ".", ",") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "REPAIRDISCOUNTPERCENTAGE");
               AnyError = 1;
               GX_FocusControl = edtRepairDiscountPercentage_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A31RepairDiscountPercentage = 0;
               AssignAttri("", false, "A31RepairDiscountPercentage", StringUtil.LTrimStr( (decimal)(A31RepairDiscountPercentage), 3, 0));
            }
            else
            {
               A31RepairDiscountPercentage = (short)(context.localUtil.CToN( cgiGet( edtRepairDiscountPercentage_Internalname), ".", ","));
               AssignAttri("", false, "A31RepairDiscountPercentage", StringUtil.LTrimStr( (decimal)(A31RepairDiscountPercentage), 3, 0));
            }
            A32RepairFinalCost = (short)(context.localUtil.CToN( cgiGet( edtRepairFinalCost_Internalname), ".", ","));
            AssignAttri("", false, "A32RepairFinalCost", StringUtil.LTrimStr( (decimal)(A32RepairFinalCost), 4, 0));
            A36RepairProblems = (short)(context.localUtil.CToN( cgiGet( edtRepairProblems_Internalname), ".", ","));
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A22RepairId = (short)(NumberUtil.Val( GetPar( "RepairId"), "."));
               AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
                        }
                     }
                     else
                     {
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
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
               /* Clear variables for new insertion. */
               InitAll067( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
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

      protected void disable_std_buttons( )
      {
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes067( ) ;
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_069( )
      {
         s36RepairProblems = O36RepairProblems;
         n36RepairProblems = false;
         AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         nGXsfl_108_idx = 0;
         while ( nGXsfl_108_idx < nRC_GXsfl_108 )
         {
            ReadRow069( ) ;
            if ( ( nRcdExists_9 != 0 ) || ( nIsMod_9 != 0 ) )
            {
               GetKey069( ) ;
               if ( ( nRcdExists_9 == 0 ) && ( nRcdDeleted_9 == 0 ) )
               {
                  if ( RcdFound9 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate069( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable069( ) ;
                        CloseExtendedTableCursors069( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O36RepairProblems = A36RepairProblems;
                        n36RepairProblems = false;
                        AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                     }
                  }
                  else
                  {
                     GXCCtl = "REPAIRKINDID_" + sGXsfl_108_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtRepairKindId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( nRcdDeleted_9 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey069( ) ;
                        Load069( ) ;
                        BeforeValidate069( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls069( ) ;
                           O36RepairProblems = A36RepairProblems;
                           n36RepairProblems = false;
                           AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                        }
                     }
                     else
                     {
                        if ( nIsMod_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate069( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable069( ) ;
                              CloseExtendedTableCursors069( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O36RepairProblems = A36RepairProblems;
                              n36RepairProblems = false;
                              AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_9 == 0 )
                     {
                        GXCCtl = "REPAIRKINDID_" + sGXsfl_108_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRepairKindId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtRepairKindId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33RepairKindId), 1, 0, ".", ""))) ;
            ChangePostValue( cmbRepairKindName_Internalname, StringUtil.RTrim( A37RepairKindName)) ;
            ChangePostValue( edtRepairKindRemarks_Internalname, StringUtil.RTrim( A35RepairKindRemarks)) ;
            ChangePostValue( "ZT_"+"Z33RepairKindId_"+sGXsfl_108_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33RepairKindId), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z37RepairKindName_"+sGXsfl_108_idx, StringUtil.RTrim( Z37RepairKindName)) ;
            ChangePostValue( "ZT_"+"Z35RepairKindRemarks_"+sGXsfl_108_idx, StringUtil.RTrim( Z35RepairKindRemarks)) ;
            ChangePostValue( "nRcdDeleted_9_"+sGXsfl_108_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_9_"+sGXsfl_108_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_9_"+sGXsfl_108_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", ""))) ;
            if ( nIsMod_9 != 0 )
            {
               ChangePostValue( "REPAIRKINDID_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRepairKindId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "REPAIRKINDNAME_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRepairKindName.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "REPAIRKINDREMARKS_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRepairKindRemarks_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O36RepairProblems = s36RepairProblems;
         n36RepairProblems = false;
         AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption060( )
      {
      }

      protected void ZM067( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z23RepairDateFrom = T00065_A23RepairDateFrom[0];
               Z24RepairDaysQuantity = T00065_A24RepairDaysQuantity[0];
               Z26RepairCost = T00065_A26RepairCost[0];
               Z31RepairDiscountPercentage = T00065_A31RepairDiscountPercentage[0];
               Z16GameId = T00065_A16GameId[0];
               Z27TechnicianId = T00065_A27TechnicianId[0];
               Z29RepairAlternateTechnicianId = T00065_A29RepairAlternateTechnicianId[0];
            }
            else
            {
               Z23RepairDateFrom = A23RepairDateFrom;
               Z24RepairDaysQuantity = A24RepairDaysQuantity;
               Z26RepairCost = A26RepairCost;
               Z31RepairDiscountPercentage = A31RepairDiscountPercentage;
               Z16GameId = A16GameId;
               Z27TechnicianId = A27TechnicianId;
               Z29RepairAlternateTechnicianId = A29RepairAlternateTechnicianId;
            }
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
         imgprompt_16_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"GAMEID"+"'), id:'"+"GAMEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_27_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"TECHNICIANID"+"'), id:'"+"TECHNICIANID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_29_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0080.aspx"+"',["+"{Ctrl:gx.dom.el('"+"REPAIRALTERNATETECHNICIANID"+"'), id:'"+"REPAIRALTERNATETECHNICIANID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load067( )
      {
         /* Using cursor T000612 */
         pr_default.execute(8, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound7 = 1;
            A23RepairDateFrom = T000612_A23RepairDateFrom[0];
            AssignAttri("", false, "A23RepairDateFrom", context.localUtil.Format(A23RepairDateFrom, "99/99/99"));
            A24RepairDaysQuantity = T000612_A24RepairDaysQuantity[0];
            AssignAttri("", false, "A24RepairDaysQuantity", StringUtil.LTrimStr( (decimal)(A24RepairDaysQuantity), 4, 0));
            A17GameName = T000612_A17GameName[0];
            AssignAttri("", false, "A17GameName", A17GameName);
            A26RepairCost = T000612_A26RepairCost[0];
            AssignAttri("", false, "A26RepairCost", StringUtil.LTrimStr( (decimal)(A26RepairCost), 4, 0));
            A28TechnicianName = T000612_A28TechnicianName[0];
            AssignAttri("", false, "A28TechnicianName", A28TechnicianName);
            A30RepairAlternateTechnicianName = T000612_A30RepairAlternateTechnicianName[0];
            AssignAttri("", false, "A30RepairAlternateTechnicianName", A30RepairAlternateTechnicianName);
            A31RepairDiscountPercentage = T000612_A31RepairDiscountPercentage[0];
            AssignAttri("", false, "A31RepairDiscountPercentage", StringUtil.LTrimStr( (decimal)(A31RepairDiscountPercentage), 3, 0));
            A16GameId = T000612_A16GameId[0];
            AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            A27TechnicianId = T000612_A27TechnicianId[0];
            AssignAttri("", false, "A27TechnicianId", StringUtil.LTrimStr( (decimal)(A27TechnicianId), 4, 0));
            A29RepairAlternateTechnicianId = T000612_A29RepairAlternateTechnicianId[0];
            AssignAttri("", false, "A29RepairAlternateTechnicianId", StringUtil.LTrimStr( (decimal)(A29RepairAlternateTechnicianId), 4, 0));
            A36RepairProblems = T000612_A36RepairProblems[0];
            n36RepairProblems = T000612_n36RepairProblems[0];
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            ZM067( -6) ;
         }
         pr_default.close(8);
         OnLoadActions067( ) ;
      }

      protected void OnLoadActions067( )
      {
         O36RepairProblems = A36RepairProblems;
         n36RepairProblems = false;
         AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         A25RepairDateTo = DateTimeUtil.DAdd(A23RepairDateFrom,+((int)(A24RepairDaysQuantity)));
         AssignAttri("", false, "A25RepairDateTo", context.localUtil.Format(A25RepairDateTo, "99/99/99"));
         A32RepairFinalCost = (short)(A26RepairCost*(1-A31RepairDiscountPercentage/ (decimal)(100)));
         AssignAttri("", false, "A32RepairFinalCost", StringUtil.LTrimStr( (decimal)(A32RepairFinalCost), 4, 0));
      }

      protected void CheckExtendedTable067( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000610 */
         pr_default.execute(7, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A36RepairProblems = T000610_A36RepairProblems[0];
            n36RepairProblems = T000610_n36RepairProblems[0];
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         else
         {
            nIsDirty_7 = 1;
            A36RepairProblems = 0;
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         pr_default.close(7);
         if ( ! ( (DateTime.MinValue==A23RepairDateFrom) || ( DateTimeUtil.ResetTime ( A23RepairDateFrom ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Repair Date From is out of range", "OutOfRange", 1, "REPAIRDATEFROM");
            AnyError = 1;
            GX_FocusControl = edtRepairDateFrom_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_7 = 1;
         A25RepairDateTo = DateTimeUtil.DAdd(A23RepairDateFrom,+((int)(A24RepairDaysQuantity)));
         AssignAttri("", false, "A25RepairDateTo", context.localUtil.Format(A25RepairDateTo, "99/99/99"));
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A16GameId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Game'.", "ForeignKeyNotFound", 1, "GAMEID");
            AnyError = 1;
            GX_FocusControl = edtGameId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A17GameName = T00066_A17GameName[0];
         AssignAttri("", false, "A17GameName", A17GameName);
         pr_default.close(4);
         nIsDirty_7 = 1;
         A32RepairFinalCost = (short)(A26RepairCost*(1-A31RepairDiscountPercentage/ (decimal)(100)));
         AssignAttri("", false, "A32RepairFinalCost", StringUtil.LTrimStr( (decimal)(A32RepairFinalCost), 4, 0));
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A27TechnicianId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Technician'.", "ForeignKeyNotFound", 1, "TECHNICIANID");
            AnyError = 1;
            GX_FocusControl = edtTechnicianId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28TechnicianName = T00067_A28TechnicianName[0];
         AssignAttri("", false, "A28TechnicianName", A28TechnicianName);
         pr_default.close(5);
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A29RepairAlternateTechnicianId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Repair Alternate Technician'.", "ForeignKeyNotFound", 1, "REPAIRALTERNATETECHNICIANID");
            AnyError = 1;
            GX_FocusControl = edtRepairAlternateTechnicianId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30RepairAlternateTechnicianName = T00068_A30RepairAlternateTechnicianName[0];
         AssignAttri("", false, "A30RepairAlternateTechnicianName", A30RepairAlternateTechnicianName);
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

      protected void gxLoad_10( short A22RepairId )
      {
         /* Using cursor T000614 */
         pr_default.execute(9, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A36RepairProblems = T000614_A36RepairProblems[0];
            n36RepairProblems = T000614_n36RepairProblems[0];
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         else
         {
            A36RepairProblems = 0;
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A36RepairProblems), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_7( short A16GameId )
      {
         /* Using cursor T000615 */
         pr_default.execute(10, new Object[] {A16GameId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No matching 'Game'.", "ForeignKeyNotFound", 1, "GAMEID");
            AnyError = 1;
            GX_FocusControl = edtGameId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A17GameName = T000615_A17GameName[0];
         AssignAttri("", false, "A17GameName", A17GameName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A17GameName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_8( short A27TechnicianId )
      {
         /* Using cursor T000616 */
         pr_default.execute(11, new Object[] {A27TechnicianId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Technician'.", "ForeignKeyNotFound", 1, "TECHNICIANID");
            AnyError = 1;
            GX_FocusControl = edtTechnicianId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A28TechnicianName = T000616_A28TechnicianName[0];
         AssignAttri("", false, "A28TechnicianName", A28TechnicianName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A28TechnicianName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_9( short A29RepairAlternateTechnicianId )
      {
         /* Using cursor T000617 */
         pr_default.execute(12, new Object[] {A29RepairAlternateTechnicianId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'Repair Alternate Technician'.", "ForeignKeyNotFound", 1, "REPAIRALTERNATETECHNICIANID");
            AnyError = 1;
            GX_FocusControl = edtRepairAlternateTechnicianId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30RepairAlternateTechnicianName = T000617_A30RepairAlternateTechnicianName[0];
         AssignAttri("", false, "A30RepairAlternateTechnicianName", A30RepairAlternateTechnicianName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A30RepairAlternateTechnicianName))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey067( )
      {
         /* Using cursor T000618 */
         pr_default.execute(13, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM067( 6) ;
            RcdFound7 = 1;
            A22RepairId = T00065_A22RepairId[0];
            AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
            A23RepairDateFrom = T00065_A23RepairDateFrom[0];
            AssignAttri("", false, "A23RepairDateFrom", context.localUtil.Format(A23RepairDateFrom, "99/99/99"));
            A24RepairDaysQuantity = T00065_A24RepairDaysQuantity[0];
            AssignAttri("", false, "A24RepairDaysQuantity", StringUtil.LTrimStr( (decimal)(A24RepairDaysQuantity), 4, 0));
            A26RepairCost = T00065_A26RepairCost[0];
            AssignAttri("", false, "A26RepairCost", StringUtil.LTrimStr( (decimal)(A26RepairCost), 4, 0));
            A31RepairDiscountPercentage = T00065_A31RepairDiscountPercentage[0];
            AssignAttri("", false, "A31RepairDiscountPercentage", StringUtil.LTrimStr( (decimal)(A31RepairDiscountPercentage), 3, 0));
            A16GameId = T00065_A16GameId[0];
            AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
            A27TechnicianId = T00065_A27TechnicianId[0];
            AssignAttri("", false, "A27TechnicianId", StringUtil.LTrimStr( (decimal)(A27TechnicianId), 4, 0));
            A29RepairAlternateTechnicianId = T00065_A29RepairAlternateTechnicianId[0];
            AssignAttri("", false, "A29RepairAlternateTechnicianId", StringUtil.LTrimStr( (decimal)(A29RepairAlternateTechnicianId), 4, 0));
            Z22RepairId = A22RepairId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load067( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey067( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey067( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey067( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T000619 */
         pr_default.execute(14, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000619_A22RepairId[0] < A22RepairId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000619_A22RepairId[0] > A22RepairId ) ) )
            {
               A22RepairId = T000619_A22RepairId[0];
               AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T000620 */
         pr_default.execute(15, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000620_A22RepairId[0] > A22RepairId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000620_A22RepairId[0] < A22RepairId ) ) )
            {
               A22RepairId = T000620_A22RepairId[0];
               AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey067( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A36RepairProblems = O36RepairProblems;
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            GX_FocusControl = edtRepairId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert067( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A22RepairId != Z22RepairId )
               {
                  A22RepairId = Z22RepairId;
                  AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "REPAIRID");
                  AnyError = 1;
                  GX_FocusControl = edtRepairId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A36RepairProblems = O36RepairProblems;
                  n36RepairProblems = false;
                  AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtRepairId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  A36RepairProblems = O36RepairProblems;
                  n36RepairProblems = false;
                  AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                  Update067( ) ;
                  GX_FocusControl = edtRepairId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A22RepairId != Z22RepairId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  A36RepairProblems = O36RepairProblems;
                  n36RepairProblems = false;
                  AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                  GX_FocusControl = edtRepairId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert067( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "REPAIRID");
                     AnyError = 1;
                     GX_FocusControl = edtRepairId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     A36RepairProblems = O36RepairProblems;
                     n36RepairProblems = false;
                     AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                     GX_FocusControl = edtRepairId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert067( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      protected void btn_delete( )
      {
         if ( A22RepairId != Z22RepairId )
         {
            A22RepairId = Z22RepairId;
            AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "REPAIRID");
            AnyError = 1;
            GX_FocusControl = edtRepairId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A36RepairProblems = O36RepairProblems;
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtRepairId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "REPAIRID");
            AnyError = 1;
            GX_FocusControl = edtRepairId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtRepairDateFrom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart067( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRepairDateFrom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd067( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRepairDateFrom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRepairDateFrom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart067( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound7 != 0 )
            {
               ScanNext067( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtRepairDateFrom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd067( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency067( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A22RepairId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Repair"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( DateTimeUtil.ResetTime ( Z23RepairDateFrom ) != DateTimeUtil.ResetTime ( T00064_A23RepairDateFrom[0] ) ) || ( Z24RepairDaysQuantity != T00064_A24RepairDaysQuantity[0] ) || ( Z26RepairCost != T00064_A26RepairCost[0] ) || ( Z31RepairDiscountPercentage != T00064_A31RepairDiscountPercentage[0] ) || ( Z16GameId != T00064_A16GameId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z27TechnicianId != T00064_A27TechnicianId[0] ) || ( Z29RepairAlternateTechnicianId != T00064_A29RepairAlternateTechnicianId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z23RepairDateFrom ) != DateTimeUtil.ResetTime ( T00064_A23RepairDateFrom[0] ) )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"RepairDateFrom");
                  GXUtil.WriteLogRaw("Old: ",Z23RepairDateFrom);
                  GXUtil.WriteLogRaw("Current: ",T00064_A23RepairDateFrom[0]);
               }
               if ( Z24RepairDaysQuantity != T00064_A24RepairDaysQuantity[0] )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"RepairDaysQuantity");
                  GXUtil.WriteLogRaw("Old: ",Z24RepairDaysQuantity);
                  GXUtil.WriteLogRaw("Current: ",T00064_A24RepairDaysQuantity[0]);
               }
               if ( Z26RepairCost != T00064_A26RepairCost[0] )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"RepairCost");
                  GXUtil.WriteLogRaw("Old: ",Z26RepairCost);
                  GXUtil.WriteLogRaw("Current: ",T00064_A26RepairCost[0]);
               }
               if ( Z31RepairDiscountPercentage != T00064_A31RepairDiscountPercentage[0] )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"RepairDiscountPercentage");
                  GXUtil.WriteLogRaw("Old: ",Z31RepairDiscountPercentage);
                  GXUtil.WriteLogRaw("Current: ",T00064_A31RepairDiscountPercentage[0]);
               }
               if ( Z16GameId != T00064_A16GameId[0] )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"GameId");
                  GXUtil.WriteLogRaw("Old: ",Z16GameId);
                  GXUtil.WriteLogRaw("Current: ",T00064_A16GameId[0]);
               }
               if ( Z27TechnicianId != T00064_A27TechnicianId[0] )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"TechnicianId");
                  GXUtil.WriteLogRaw("Old: ",Z27TechnicianId);
                  GXUtil.WriteLogRaw("Current: ",T00064_A27TechnicianId[0]);
               }
               if ( Z29RepairAlternateTechnicianId != T00064_A29RepairAlternateTechnicianId[0] )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"RepairAlternateTechnicianId");
                  GXUtil.WriteLogRaw("Old: ",Z29RepairAlternateTechnicianId);
                  GXUtil.WriteLogRaw("Current: ",T00064_A29RepairAlternateTechnicianId[0]);
               }
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
                     /* Using cursor T000621 */
                     pr_default.execute(16, new Object[] {A23RepairDateFrom, A24RepairDaysQuantity, A26RepairCost, A31RepairDiscountPercentage, A16GameId, A27TechnicianId, A29RepairAlternateTechnicianId});
                     A22RepairId = T000621_A22RepairId[0];
                     AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
                     pr_default.close(16);
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
                              ResetCaption060( ) ;
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
                     /* Using cursor T000622 */
                     pr_default.execute(17, new Object[] {A23RepairDateFrom, A24RepairDaysQuantity, A26RepairCost, A31RepairDiscountPercentage, A16GameId, A27TechnicianId, A29RepairAlternateTechnicianId, A22RepairId});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("Repair");
                     if ( (pr_default.getStatus(17) == 103) )
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
                              ResetCaption060( ) ;
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                  ScanStart069( ) ;
                  while ( RcdFound9 != 0 )
                  {
                     getByPrimaryKey069( ) ;
                     Delete069( ) ;
                     ScanNext069( ) ;
                     O36RepairProblems = A36RepairProblems;
                     n36RepairProblems = false;
                     AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
                  }
                  ScanEnd069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000623 */
                     pr_default.execute(18, new Object[] {A22RepairId});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("Repair");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound7 == 0 )
                           {
                              InitAll067( ) ;
                              Gx_mode = "INS";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           else
                           {
                              getByPrimaryKey( ) ;
                              Gx_mode = "UPD";
                              AssignAttri("", false, "Gx_mode", Gx_mode);
                           }
                           endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                           endTrnMsgCod = "SuccessfullyDeleted";
                           ResetCaption060( ) ;
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel067( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls067( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000625 */
            pr_default.execute(19, new Object[] {A22RepairId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A36RepairProblems = T000625_A36RepairProblems[0];
               n36RepairProblems = T000625_n36RepairProblems[0];
               AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            }
            else
            {
               A36RepairProblems = 0;
               n36RepairProblems = false;
               AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            }
            pr_default.close(19);
            A25RepairDateTo = DateTimeUtil.DAdd(A23RepairDateFrom,+((int)(A24RepairDaysQuantity)));
            AssignAttri("", false, "A25RepairDateTo", context.localUtil.Format(A25RepairDateTo, "99/99/99"));
            /* Using cursor T000626 */
            pr_default.execute(20, new Object[] {A16GameId});
            A17GameName = T000626_A17GameName[0];
            AssignAttri("", false, "A17GameName", A17GameName);
            pr_default.close(20);
            /* Using cursor T000627 */
            pr_default.execute(21, new Object[] {A27TechnicianId});
            A28TechnicianName = T000627_A28TechnicianName[0];
            AssignAttri("", false, "A28TechnicianName", A28TechnicianName);
            pr_default.close(21);
            /* Using cursor T000628 */
            pr_default.execute(22, new Object[] {A29RepairAlternateTechnicianId});
            A30RepairAlternateTechnicianName = T000628_A30RepairAlternateTechnicianName[0];
            AssignAttri("", false, "A30RepairAlternateTechnicianName", A30RepairAlternateTechnicianName);
            pr_default.close(22);
            A32RepairFinalCost = (short)(A26RepairCost*(1-A31RepairDiscountPercentage/ (decimal)(100)));
            AssignAttri("", false, "A32RepairFinalCost", StringUtil.LTrimStr( (decimal)(A32RepairFinalCost), 4, 0));
         }
      }

      protected void ProcessNestedLevel069( )
      {
         s36RepairProblems = O36RepairProblems;
         n36RepairProblems = false;
         AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         nGXsfl_108_idx = 0;
         while ( nGXsfl_108_idx < nRC_GXsfl_108 )
         {
            ReadRow069( ) ;
            if ( ( nRcdExists_9 != 0 ) || ( nIsMod_9 != 0 ) )
            {
               standaloneNotModal069( ) ;
               GetKey069( ) ;
               if ( ( nRcdExists_9 == 0 ) && ( nRcdDeleted_9 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert069( ) ;
               }
               else
               {
                  if ( RcdFound9 != 0 )
                  {
                     if ( ( nRcdDeleted_9 != 0 ) && ( nRcdExists_9 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete069( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_9 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update069( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_9 == 0 )
                     {
                        GXCCtl = "REPAIRKINDID_" + sGXsfl_108_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtRepairKindId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O36RepairProblems = A36RepairProblems;
               n36RepairProblems = false;
               AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            }
            ChangePostValue( edtRepairKindId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A33RepairKindId), 1, 0, ".", ""))) ;
            ChangePostValue( cmbRepairKindName_Internalname, StringUtil.RTrim( A37RepairKindName)) ;
            ChangePostValue( edtRepairKindRemarks_Internalname, StringUtil.RTrim( A35RepairKindRemarks)) ;
            ChangePostValue( "ZT_"+"Z33RepairKindId_"+sGXsfl_108_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33RepairKindId), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z37RepairKindName_"+sGXsfl_108_idx, StringUtil.RTrim( Z37RepairKindName)) ;
            ChangePostValue( "ZT_"+"Z35RepairKindRemarks_"+sGXsfl_108_idx, StringUtil.RTrim( Z35RepairKindRemarks)) ;
            ChangePostValue( "nRcdDeleted_9_"+sGXsfl_108_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_9_"+sGXsfl_108_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_9_"+sGXsfl_108_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", ""))) ;
            if ( nIsMod_9 != 0 )
            {
               ChangePostValue( "REPAIRKINDID_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRepairKindId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "REPAIRKINDNAME_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRepairKindName.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "REPAIRKINDREMARKS_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRepairKindRemarks_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll069( ) ;
         if ( AnyError != 0 )
         {
            O36RepairProblems = s36RepairProblems;
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         nRcdExists_9 = 0;
         nIsMod_9 = 0;
         nRcdDeleted_9 = 0;
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
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         /* Restore parent mode. */
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(19);
            context.CommitDataStores("repair",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(19);
            context.RollbackDataStores("repair",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart067( )
      {
         /* Using cursor T000629 */
         pr_default.execute(23);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound7 = 1;
            A22RepairId = T000629_A22RepairId[0];
            AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext067( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound7 = 1;
            A22RepairId = T000629_A22RepairId[0];
            AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
         }
      }

      protected void ScanEnd067( )
      {
         pr_default.close(23);
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
         edtRepairId_Enabled = 0;
         AssignProp("", false, edtRepairId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairId_Enabled), 5, 0), true);
         edtRepairDateFrom_Enabled = 0;
         AssignProp("", false, edtRepairDateFrom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairDateFrom_Enabled), 5, 0), true);
         edtRepairDaysQuantity_Enabled = 0;
         AssignProp("", false, edtRepairDaysQuantity_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairDaysQuantity_Enabled), 5, 0), true);
         edtRepairDateTo_Enabled = 0;
         AssignProp("", false, edtRepairDateTo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairDateTo_Enabled), 5, 0), true);
         edtGameId_Enabled = 0;
         AssignProp("", false, edtGameId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGameId_Enabled), 5, 0), true);
         edtGameName_Enabled = 0;
         AssignProp("", false, edtGameName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGameName_Enabled), 5, 0), true);
         edtRepairCost_Enabled = 0;
         AssignProp("", false, edtRepairCost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairCost_Enabled), 5, 0), true);
         edtTechnicianId_Enabled = 0;
         AssignProp("", false, edtTechnicianId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTechnicianId_Enabled), 5, 0), true);
         edtTechnicianName_Enabled = 0;
         AssignProp("", false, edtTechnicianName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTechnicianName_Enabled), 5, 0), true);
         edtRepairAlternateTechnicianId_Enabled = 0;
         AssignProp("", false, edtRepairAlternateTechnicianId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairAlternateTechnicianId_Enabled), 5, 0), true);
         edtRepairAlternateTechnicianName_Enabled = 0;
         AssignProp("", false, edtRepairAlternateTechnicianName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairAlternateTechnicianName_Enabled), 5, 0), true);
         edtRepairDiscountPercentage_Enabled = 0;
         AssignProp("", false, edtRepairDiscountPercentage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairDiscountPercentage_Enabled), 5, 0), true);
         edtRepairFinalCost_Enabled = 0;
         AssignProp("", false, edtRepairFinalCost_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairFinalCost_Enabled), 5, 0), true);
         edtRepairProblems_Enabled = 0;
         AssignProp("", false, edtRepairProblems_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairProblems_Enabled), 5, 0), true);
      }

      protected void ZM069( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z37RepairKindName = T00063_A37RepairKindName[0];
               Z35RepairKindRemarks = T00063_A35RepairKindRemarks[0];
            }
            else
            {
               Z37RepairKindName = A37RepairKindName;
               Z35RepairKindRemarks = A35RepairKindRemarks;
            }
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
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtRepairKindId_Enabled = 0;
            AssignProp("", false, edtRepairKindId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairKindId_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         }
         else
         {
            edtRepairKindId_Enabled = 1;
            AssignProp("", false, edtRepairKindId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairKindId_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         }
      }

      protected void Load069( )
      {
         /* Using cursor T000630 */
         pr_default.execute(24, new Object[] {A22RepairId, A33RepairKindId});
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound9 = 1;
            A37RepairKindName = T000630_A37RepairKindName[0];
            A35RepairKindRemarks = T000630_A35RepairKindRemarks[0];
            ZM069( -11) ;
         }
         pr_default.close(24);
         OnLoadActions069( ) ;
      }

      protected void OnLoadActions069( )
      {
         if ( IsIns( )  )
         {
            A36RepairProblems = (short)(O36RepairProblems+1);
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A36RepairProblems = O36RepairProblems;
               n36RepairProblems = false;
               AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A36RepairProblems = (short)(O36RepairProblems-1);
                  n36RepairProblems = false;
                  AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
               }
            }
         }
      }

      protected void CheckExtendedTable069( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         standaloneModal069( ) ;
         if ( ! ( ( StringUtil.StrCmp(A37RepairKindName, "E") == 0 ) || ( StringUtil.StrCmp(A37RepairKindName, "M") == 0 ) || ( StringUtil.StrCmp(A37RepairKindName, "R") == 0 ) ) )
         {
            GXCCtl = "REPAIRKINDNAME_" + sGXsfl_108_idx;
            GX_msglist.addItem("Field Repair Kind Name is out of range", "OutOfRange", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = cmbRepairKindName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( IsIns( )  )
         {
            nIsDirty_9 = 1;
            A36RepairProblems = (short)(O36RepairProblems+1);
            n36RepairProblems = false;
            AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_9 = 1;
               A36RepairProblems = O36RepairProblems;
               n36RepairProblems = false;
               AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_9 = 1;
                  A36RepairProblems = (short)(O36RepairProblems-1);
                  n36RepairProblems = false;
                  AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
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
         /* Using cursor T000631 */
         pr_default.execute(25, new Object[] {A22RepairId, A33RepairKindId});
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(25);
      }

      protected void getByPrimaryKey069( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A22RepairId, A33RepairKindId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM069( 11) ;
            RcdFound9 = 1;
            InitializeNonKey069( ) ;
            A33RepairKindId = T00063_A33RepairKindId[0];
            A37RepairKindName = T00063_A37RepairKindName[0];
            A35RepairKindRemarks = T00063_A35RepairKindRemarks[0];
            Z22RepairId = A22RepairId;
            Z33RepairKindId = A33RepairKindId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal069( ) ;
            Load069( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey069( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal069( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
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
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A22RepairId, A33RepairKindId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"RepairRepairTransaction"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z37RepairKindName, T00062_A37RepairKindName[0]) != 0 ) || ( StringUtil.StrCmp(Z35RepairKindRemarks, T00062_A35RepairKindRemarks[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z37RepairKindName, T00062_A37RepairKindName[0]) != 0 )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"RepairKindName");
                  GXUtil.WriteLogRaw("Old: ",Z37RepairKindName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A37RepairKindName[0]);
               }
               if ( StringUtil.StrCmp(Z35RepairKindRemarks, T00062_A35RepairKindRemarks[0]) != 0 )
               {
                  GXUtil.WriteLog("repair:[seudo value changed for attri]"+"RepairKindRemarks");
                  GXUtil.WriteLogRaw("Old: ",Z35RepairKindRemarks);
                  GXUtil.WriteLogRaw("Current: ",T00062_A35RepairKindRemarks[0]);
               }
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
                     /* Using cursor T000632 */
                     pr_default.execute(26, new Object[] {A22RepairId, A33RepairKindId, A37RepairKindName, A35RepairKindRemarks});
                     pr_default.close(26);
                     dsDefault.SmartCacheProvider.SetUpdated("RepairRepairTransaction");
                     if ( (pr_default.getStatus(26) == 1) )
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
         if ( ( nIsMod_9 != 0 ) || ( nIsDirty_9 != 0 ) )
         {
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
                        /* Using cursor T000633 */
                        pr_default.execute(27, new Object[] {A37RepairKindName, A35RepairKindRemarks, A22RepairId, A33RepairKindId});
                        pr_default.close(27);
                        dsDefault.SmartCacheProvider.SetUpdated("RepairRepairTransaction");
                        if ( (pr_default.getStatus(27) == 103) )
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
         }
         CloseExtendedTableCursors069( ) ;
      }

      protected void DeferredUpdate069( )
      {
      }

      protected void Delete069( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
                  /* Using cursor T000634 */
                  pr_default.execute(28, new Object[] {A22RepairId, A33RepairKindId});
                  pr_default.close(28);
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
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel069( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
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
               AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A36RepairProblems = O36RepairProblems;
                  n36RepairProblems = false;
                  AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A36RepairProblems = (short)(O36RepairProblems-1);
                     n36RepairProblems = false;
                     AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
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

      public void ScanStart069( )
      {
         /* Scan By routine */
         /* Using cursor T000635 */
         pr_default.execute(29, new Object[] {A22RepairId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound9 = 1;
            A33RepairKindId = T000635_A33RepairKindId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext069( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound9 = 1;
            A33RepairKindId = T000635_A33RepairKindId[0];
         }
      }

      protected void ScanEnd069( )
      {
         pr_default.close(29);
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
         edtRepairKindId_Enabled = 0;
         AssignProp("", false, edtRepairKindId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairKindId_Enabled), 5, 0), !bGXsfl_108_Refreshing);
         cmbRepairKindName.Enabled = 0;
         AssignProp("", false, cmbRepairKindName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRepairKindName.Enabled), 5, 0), !bGXsfl_108_Refreshing);
         edtRepairKindRemarks_Enabled = 0;
         AssignProp("", false, edtRepairKindRemarks_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairKindRemarks_Enabled), 5, 0), !bGXsfl_108_Refreshing);
      }

      protected void send_integrity_lvl_hashes069( )
      {
      }

      protected void send_integrity_lvl_hashes067( )
      {
      }

      protected void SubsflControlProps_1089( )
      {
         edtRepairKindId_Internalname = "REPAIRKINDID_"+sGXsfl_108_idx;
         cmbRepairKindName_Internalname = "REPAIRKINDNAME_"+sGXsfl_108_idx;
         edtRepairKindRemarks_Internalname = "REPAIRKINDREMARKS_"+sGXsfl_108_idx;
      }

      protected void SubsflControlProps_fel_1089( )
      {
         edtRepairKindId_Internalname = "REPAIRKINDID_"+sGXsfl_108_fel_idx;
         cmbRepairKindName_Internalname = "REPAIRKINDNAME_"+sGXsfl_108_fel_idx;
         edtRepairKindRemarks_Internalname = "REPAIRKINDREMARKS_"+sGXsfl_108_fel_idx;
      }

      protected void AddRow069( )
      {
         nGXsfl_108_idx = (int)(nGXsfl_108_idx+1);
         sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
         SubsflControlProps_1089( ) ;
         SendRow069( ) ;
      }

      protected void SendRow069( )
      {
         Gridrepair_kindRow = GXWebRow.GetNew(context);
         if ( subGridrepair_kind_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridrepair_kind_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridrepair_kind_Class, "") != 0 )
            {
               subGridrepair_kind_Linesclass = subGridrepair_kind_Class+"Odd";
            }
         }
         else if ( subGridrepair_kind_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridrepair_kind_Backstyle = 0;
            subGridrepair_kind_Backcolor = subGridrepair_kind_Allbackcolor;
            if ( StringUtil.StrCmp(subGridrepair_kind_Class, "") != 0 )
            {
               subGridrepair_kind_Linesclass = subGridrepair_kind_Class+"Uniform";
            }
         }
         else if ( subGridrepair_kind_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridrepair_kind_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridrepair_kind_Class, "") != 0 )
            {
               subGridrepair_kind_Linesclass = subGridrepair_kind_Class+"Odd";
            }
            subGridrepair_kind_Backcolor = (int)(0x0);
         }
         else if ( subGridrepair_kind_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridrepair_kind_Backstyle = 1;
            if ( ((int)((nGXsfl_108_idx) % (2))) == 0 )
            {
               subGridrepair_kind_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridrepair_kind_Class, "") != 0 )
               {
                  subGridrepair_kind_Linesclass = subGridrepair_kind_Class+"Even";
               }
            }
            else
            {
               subGridrepair_kind_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridrepair_kind_Class, "") != 0 )
               {
                  subGridrepair_kind_Linesclass = subGridrepair_kind_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_108_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 109,'',false,'" + sGXsfl_108_idx + "',108)\"";
         ROClassString = "Attribute";
         Gridrepair_kindRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepairKindId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A33RepairKindId), 1, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A33RepairKindId), "9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,109);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepairKindId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtRepairKindId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)108,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_108_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 110,'',false,'" + sGXsfl_108_idx + "',108)\"";
         if ( ( cmbRepairKindName.ItemCount == 0 ) && isAjaxCallMode( ) )
         {
            GXCCtl = "REPAIRKINDNAME_" + sGXsfl_108_idx;
            cmbRepairKindName.Name = GXCCtl;
            cmbRepairKindName.WebTags = "";
            cmbRepairKindName.addItem("E", "Electricity", 0);
            cmbRepairKindName.addItem("M", "Mechanical", 0);
            cmbRepairKindName.addItem("R", "Replacement", 0);
            if ( cmbRepairKindName.ItemCount > 0 )
            {
               A37RepairKindName = cmbRepairKindName.getValidValue(A37RepairKindName);
            }
         }
         /* ComboBox */
         Gridrepair_kindRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbRepairKindName,(string)cmbRepairKindName_Internalname,StringUtil.RTrim( A37RepairKindName),(short)1,(string)cmbRepairKindName_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)-1,cmbRepairKindName.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,110);\"",(string)"",(bool)true,(short)1});
         cmbRepairKindName.CurrentValue = StringUtil.RTrim( A37RepairKindName);
         AssignProp("", false, cmbRepairKindName_Internalname, "Values", (string)(cmbRepairKindName.ToJavascriptSource()), !bGXsfl_108_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_9_" + sGXsfl_108_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 111,'',false,'" + sGXsfl_108_idx + "',108)\"";
         ROClassString = "Attribute";
         Gridrepair_kindRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtRepairKindRemarks_Internalname,StringUtil.RTrim( A35RepairKindRemarks),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtRepairKindRemarks_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtRepairKindRemarks_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)108,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         context.httpAjaxContext.ajax_sending_grid_row(Gridrepair_kindRow);
         send_integrity_lvl_hashes069( ) ;
         GXCCtl = "Z33RepairKindId_" + sGXsfl_108_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z33RepairKindId), 1, 0, ".", "")));
         GXCCtl = "Z37RepairKindName_" + sGXsfl_108_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z37RepairKindName));
         GXCCtl = "Z35RepairKindRemarks_" + sGXsfl_108_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z35RepairKindRemarks));
         GXCCtl = "nRcdDeleted_9_" + sGXsfl_108_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_9), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_9_" + sGXsfl_108_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_9), 4, 0, ".", "")));
         GXCCtl = "nIsMod_9_" + sGXsfl_108_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_9), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPAIRKINDID_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRepairKindId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPAIRKINDNAME_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbRepairKindName.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "REPAIRKINDREMARKS_"+sGXsfl_108_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtRepairKindRemarks_Enabled), 5, 0, ".", "")));
         context.httpAjaxContext.ajax_sending_grid_row(null);
         Gridrepair_kindContainer.AddRow(Gridrepair_kindRow);
      }

      protected void ReadRow069( )
      {
         nGXsfl_108_idx = (int)(nGXsfl_108_idx+1);
         sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
         SubsflControlProps_1089( ) ;
         edtRepairKindId_Enabled = (int)(context.localUtil.CToN( cgiGet( "REPAIRKINDID_"+sGXsfl_108_idx+"Enabled"), ".", ","));
         cmbRepairKindName.Enabled = (int)(context.localUtil.CToN( cgiGet( "REPAIRKINDNAME_"+sGXsfl_108_idx+"Enabled"), ".", ","));
         edtRepairKindRemarks_Enabled = (int)(context.localUtil.CToN( cgiGet( "REPAIRKINDREMARKS_"+sGXsfl_108_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtRepairKindId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtRepairKindId_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
         {
            GXCCtl = "REPAIRKINDID_" + sGXsfl_108_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtRepairKindId_Internalname;
            wbErr = true;
            A33RepairKindId = 0;
         }
         else
         {
            A33RepairKindId = (short)(context.localUtil.CToN( cgiGet( edtRepairKindId_Internalname), ".", ","));
         }
         cmbRepairKindName.Name = cmbRepairKindName_Internalname;
         cmbRepairKindName.CurrentValue = cgiGet( cmbRepairKindName_Internalname);
         A37RepairKindName = cgiGet( cmbRepairKindName_Internalname);
         A35RepairKindRemarks = cgiGet( edtRepairKindRemarks_Internalname);
         GXCCtl = "Z33RepairKindId_" + sGXsfl_108_idx;
         Z33RepairKindId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z37RepairKindName_" + sGXsfl_108_idx;
         Z37RepairKindName = cgiGet( GXCCtl);
         GXCCtl = "Z35RepairKindRemarks_" + sGXsfl_108_idx;
         Z35RepairKindRemarks = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_9_" + sGXsfl_108_idx;
         nRcdDeleted_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_9_" + sGXsfl_108_idx;
         nRcdExists_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_9_" + sGXsfl_108_idx;
         nIsMod_9 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtRepairKindId_Enabled = edtRepairKindId_Enabled;
      }

      protected void ConfirmValues060( )
      {
         nGXsfl_108_idx = 0;
         sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
         SubsflControlProps_1089( ) ;
         while ( nGXsfl_108_idx < nRC_GXsfl_108 )
         {
            nGXsfl_108_idx = (int)(nGXsfl_108_idx+1);
            sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
            SubsflControlProps_1089( ) ;
            ChangePostValue( "Z33RepairKindId_"+sGXsfl_108_idx, cgiGet( "ZT_"+"Z33RepairKindId_"+sGXsfl_108_idx)) ;
            DeletePostValue( "ZT_"+"Z33RepairKindId_"+sGXsfl_108_idx) ;
            ChangePostValue( "Z37RepairKindName_"+sGXsfl_108_idx, cgiGet( "ZT_"+"Z37RepairKindName_"+sGXsfl_108_idx)) ;
            DeletePostValue( "ZT_"+"Z37RepairKindName_"+sGXsfl_108_idx) ;
            ChangePostValue( "Z35RepairKindRemarks_"+sGXsfl_108_idx, cgiGet( "ZT_"+"Z35RepairKindRemarks_"+sGXsfl_108_idx)) ;
            DeletePostValue( "ZT_"+"Z35RepairKindRemarks_"+sGXsfl_108_idx) ;
         }
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 182860), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxcfg.js", "?20236201573749", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("repair.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z22RepairId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22RepairId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23RepairDateFrom", context.localUtil.DToC( Z23RepairDateFrom, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z24RepairDaysQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24RepairDaysQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26RepairCost", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26RepairCost), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z31RepairDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31RepairDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z16GameId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16GameId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27TechnicianId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27TechnicianId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29RepairAlternateTechnicianId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29RepairAlternateTechnicianId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O36RepairProblems", StringUtil.LTrim( StringUtil.NToC( (decimal)(O36RepairProblems), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_108", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_108_idx), 8, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("repair.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Repair" ;
      }

      public override string GetPgmdesc( )
      {
         return "Repair" ;
      }

      protected void InitializeNonKey067( )
      {
         A32RepairFinalCost = 0;
         AssignAttri("", false, "A32RepairFinalCost", StringUtil.LTrimStr( (decimal)(A32RepairFinalCost), 4, 0));
         A25RepairDateTo = DateTime.MinValue;
         AssignAttri("", false, "A25RepairDateTo", context.localUtil.Format(A25RepairDateTo, "99/99/99"));
         A23RepairDateFrom = DateTime.MinValue;
         AssignAttri("", false, "A23RepairDateFrom", context.localUtil.Format(A23RepairDateFrom, "99/99/99"));
         A24RepairDaysQuantity = 0;
         AssignAttri("", false, "A24RepairDaysQuantity", StringUtil.LTrimStr( (decimal)(A24RepairDaysQuantity), 4, 0));
         A16GameId = 0;
         AssignAttri("", false, "A16GameId", StringUtil.LTrimStr( (decimal)(A16GameId), 4, 0));
         A17GameName = "";
         AssignAttri("", false, "A17GameName", A17GameName);
         A26RepairCost = 0;
         AssignAttri("", false, "A26RepairCost", StringUtil.LTrimStr( (decimal)(A26RepairCost), 4, 0));
         A27TechnicianId = 0;
         AssignAttri("", false, "A27TechnicianId", StringUtil.LTrimStr( (decimal)(A27TechnicianId), 4, 0));
         A28TechnicianName = "";
         AssignAttri("", false, "A28TechnicianName", A28TechnicianName);
         A29RepairAlternateTechnicianId = 0;
         AssignAttri("", false, "A29RepairAlternateTechnicianId", StringUtil.LTrimStr( (decimal)(A29RepairAlternateTechnicianId), 4, 0));
         A30RepairAlternateTechnicianName = "";
         AssignAttri("", false, "A30RepairAlternateTechnicianName", A30RepairAlternateTechnicianName);
         A31RepairDiscountPercentage = 0;
         AssignAttri("", false, "A31RepairDiscountPercentage", StringUtil.LTrimStr( (decimal)(A31RepairDiscountPercentage), 3, 0));
         A36RepairProblems = 0;
         n36RepairProblems = false;
         AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
         O36RepairProblems = A36RepairProblems;
         n36RepairProblems = false;
         AssignAttri("", false, "A36RepairProblems", StringUtil.Str( (decimal)(A36RepairProblems), 1, 0));
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
         AssignAttri("", false, "A22RepairId", StringUtil.LTrimStr( (decimal)(A22RepairId), 4, 0));
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

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20236201573755", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("repair.js", "?20236201573755", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties9( )
      {
         edtRepairKindId_Enabled = defedtRepairKindId_Enabled;
         AssignProp("", false, edtRepairKindId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRepairKindId_Enabled), 5, 0), !bGXsfl_108_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtRepairId_Internalname = "REPAIRID";
         edtRepairDateFrom_Internalname = "REPAIRDATEFROM";
         edtRepairDaysQuantity_Internalname = "REPAIRDAYSQUANTITY";
         edtRepairDateTo_Internalname = "REPAIRDATETO";
         edtGameId_Internalname = "GAMEID";
         edtGameName_Internalname = "GAMENAME";
         edtRepairCost_Internalname = "REPAIRCOST";
         edtTechnicianId_Internalname = "TECHNICIANID";
         edtTechnicianName_Internalname = "TECHNICIANNAME";
         edtRepairAlternateTechnicianId_Internalname = "REPAIRALTERNATETECHNICIANID";
         edtRepairAlternateTechnicianName_Internalname = "REPAIRALTERNATETECHNICIANNAME";
         edtRepairDiscountPercentage_Internalname = "REPAIRDISCOUNTPERCENTAGE";
         edtRepairFinalCost_Internalname = "REPAIRFINALCOST";
         edtRepairProblems_Internalname = "REPAIRPROBLEMS";
         lblTitlekind_Internalname = "TITLEKIND";
         edtRepairKindId_Internalname = "REPAIRKINDID";
         cmbRepairKindName_Internalname = "REPAIRKINDNAME";
         edtRepairKindRemarks_Internalname = "REPAIRKINDREMARKS";
         divKindtable_Internalname = "KINDTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_16_Internalname = "PROMPT_16";
         imgprompt_27_Internalname = "PROMPT_27";
         imgprompt_29_Internalname = "PROMPT_29";
         subGridrepair_kind_Internalname = "GRIDREPAIR_KIND";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Repair";
         edtRepairKindRemarks_Jsonclick = "";
         cmbRepairKindName_Jsonclick = "";
         edtRepairKindId_Jsonclick = "";
         subGridrepair_kind_Class = "Grid";
         subGridrepair_kind_Backcolorstyle = 0;
         subGridrepair_kind_Allowcollapsing = 0;
         subGridrepair_kind_Allowselection = 0;
         edtRepairKindRemarks_Enabled = 1;
         cmbRepairKindName.Enabled = 1;
         edtRepairKindId_Enabled = 1;
         subGridrepair_kind_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtRepairProblems_Jsonclick = "";
         edtRepairProblems_Enabled = 0;
         edtRepairFinalCost_Jsonclick = "";
         edtRepairFinalCost_Enabled = 0;
         edtRepairDiscountPercentage_Jsonclick = "";
         edtRepairDiscountPercentage_Enabled = 1;
         edtRepairAlternateTechnicianName_Jsonclick = "";
         edtRepairAlternateTechnicianName_Enabled = 0;
         imgprompt_29_Visible = 1;
         imgprompt_29_Link = "";
         edtRepairAlternateTechnicianId_Jsonclick = "";
         edtRepairAlternateTechnicianId_Enabled = 1;
         edtTechnicianName_Jsonclick = "";
         edtTechnicianName_Enabled = 0;
         imgprompt_27_Visible = 1;
         imgprompt_27_Link = "";
         edtTechnicianId_Jsonclick = "";
         edtTechnicianId_Enabled = 1;
         edtRepairCost_Jsonclick = "";
         edtRepairCost_Enabled = 1;
         edtGameName_Jsonclick = "";
         edtGameName_Enabled = 0;
         imgprompt_16_Visible = 1;
         imgprompt_16_Link = "";
         edtGameId_Jsonclick = "";
         edtGameId_Enabled = 1;
         edtRepairDateTo_Jsonclick = "";
         edtRepairDateTo_Enabled = 0;
         edtRepairDaysQuantity_Jsonclick = "";
         edtRepairDaysQuantity_Enabled = 1;
         edtRepairDateFrom_Jsonclick = "";
         edtRepairDateFrom_Enabled = 1;
         edtRepairId_Jsonclick = "";
         edtRepairId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridrepair_kind_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_1089( ) ;
         while ( nGXsfl_108_idx <= nRC_GXsfl_108 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal069( ) ;
            standaloneModal069( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow069( ) ;
            nGXsfl_108_idx = (int)(nGXsfl_108_idx+1);
            sGXsfl_108_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_108_idx), 4, 0), 4, "0");
            SubsflControlProps_1089( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridrepair_kindContainer)) ;
         /* End function gxnrGridrepair_kind_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "REPAIRKINDNAME_" + sGXsfl_108_idx;
         cmbRepairKindName.Name = GXCCtl;
         cmbRepairKindName.WebTags = "";
         cmbRepairKindName.addItem("E", "Electricity", 0);
         cmbRepairKindName.addItem("M", "Mechanical", 0);
         cmbRepairKindName.addItem("R", "Replacement", 0);
         if ( cmbRepairKindName.ItemCount > 0 )
         {
            A37RepairKindName = cmbRepairKindName.getValidValue(A37RepairKindName);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtRepairDateFrom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Repairid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000625 */
         pr_default.execute(19, new Object[] {A22RepairId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A36RepairProblems = T000625_A36RepairProblems[0];
            n36RepairProblems = T000625_n36RepairProblems[0];
         }
         else
         {
            A36RepairProblems = 0;
            n36RepairProblems = false;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A23RepairDateFrom", context.localUtil.Format(A23RepairDateFrom, "99/99/99"));
         AssignAttri("", false, "A24RepairDaysQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24RepairDaysQuantity), 4, 0, ".", "")));
         AssignAttri("", false, "A16GameId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16GameId), 4, 0, ".", "")));
         AssignAttri("", false, "A26RepairCost", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26RepairCost), 4, 0, ".", "")));
         AssignAttri("", false, "A27TechnicianId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A27TechnicianId), 4, 0, ".", "")));
         AssignAttri("", false, "A29RepairAlternateTechnicianId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A29RepairAlternateTechnicianId), 4, 0, ".", "")));
         AssignAttri("", false, "A31RepairDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(A31RepairDiscountPercentage), 3, 0, ".", "")));
         AssignAttri("", false, "A36RepairProblems", StringUtil.LTrim( StringUtil.NToC( (decimal)(A36RepairProblems), 1, 0, ".", "")));
         AssignAttri("", false, "A25RepairDateTo", context.localUtil.Format(A25RepairDateTo, "99/99/99"));
         AssignAttri("", false, "A17GameName", StringUtil.RTrim( A17GameName));
         AssignAttri("", false, "A32RepairFinalCost", StringUtil.LTrim( StringUtil.NToC( (decimal)(A32RepairFinalCost), 4, 0, ".", "")));
         AssignAttri("", false, "A28TechnicianName", StringUtil.RTrim( A28TechnicianName));
         AssignAttri("", false, "A30RepairAlternateTechnicianName", StringUtil.RTrim( A30RepairAlternateTechnicianName));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z22RepairId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22RepairId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23RepairDateFrom", context.localUtil.Format(Z23RepairDateFrom, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z24RepairDaysQuantity", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24RepairDaysQuantity), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z16GameId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16GameId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26RepairCost", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26RepairCost), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z27TechnicianId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z27TechnicianId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z29RepairAlternateTechnicianId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z29RepairAlternateTechnicianId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z31RepairDiscountPercentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z31RepairDiscountPercentage), 3, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z36RepairProblems", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z36RepairProblems), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z25RepairDateTo", context.localUtil.Format(Z25RepairDateTo, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z17GameName", StringUtil.RTrim( Z17GameName));
         GxWebStd.gx_hidden_field( context, "Z32RepairFinalCost", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32RepairFinalCost), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28TechnicianName", StringUtil.RTrim( Z28TechnicianName));
         GxWebStd.gx_hidden_field( context, "Z30RepairAlternateTechnicianName", StringUtil.RTrim( Z30RepairAlternateTechnicianName));
         AssignAttri("", false, "O36RepairProblems", StringUtil.LTrim( StringUtil.NToC( (decimal)(O36RepairProblems), 1, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Gameid( )
      {
         /* Using cursor T000626 */
         pr_default.execute(20, new Object[] {A16GameId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'Game'.", "ForeignKeyNotFound", 1, "GAMEID");
            AnyError = 1;
            GX_FocusControl = edtGameId_Internalname;
         }
         A17GameName = T000626_A17GameName[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A17GameName", StringUtil.RTrim( A17GameName));
      }

      public void Valid_Technicianid( )
      {
         /* Using cursor T000627 */
         pr_default.execute(21, new Object[] {A27TechnicianId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No matching 'Technician'.", "ForeignKeyNotFound", 1, "TECHNICIANID");
            AnyError = 1;
            GX_FocusControl = edtTechnicianId_Internalname;
         }
         A28TechnicianName = T000627_A28TechnicianName[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A28TechnicianName", StringUtil.RTrim( A28TechnicianName));
      }

      public void Valid_Repairalternatetechnicianid( )
      {
         /* Using cursor T000628 */
         pr_default.execute(22, new Object[] {A29RepairAlternateTechnicianId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No matching 'Repair Alternate Technician'.", "ForeignKeyNotFound", 1, "REPAIRALTERNATETECHNICIANID");
            AnyError = 1;
            GX_FocusControl = edtRepairAlternateTechnicianId_Internalname;
         }
         A30RepairAlternateTechnicianName = T000628_A30RepairAlternateTechnicianName[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A30RepairAlternateTechnicianName", StringUtil.RTrim( A30RepairAlternateTechnicianName));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_REPAIRID","{handler:'Valid_Repairid',iparms:[{av:'A22RepairId',fld:'REPAIRID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_REPAIRID",",oparms:[{av:'A23RepairDateFrom',fld:'REPAIRDATEFROM',pic:''},{av:'A24RepairDaysQuantity',fld:'REPAIRDAYSQUANTITY',pic:'ZZZ9'},{av:'A16GameId',fld:'GAMEID',pic:'ZZZ9'},{av:'A26RepairCost',fld:'REPAIRCOST',pic:'ZZZ9'},{av:'A27TechnicianId',fld:'TECHNICIANID',pic:'ZZZ9'},{av:'A29RepairAlternateTechnicianId',fld:'REPAIRALTERNATETECHNICIANID',pic:'ZZZ9'},{av:'A31RepairDiscountPercentage',fld:'REPAIRDISCOUNTPERCENTAGE',pic:'ZZ9'},{av:'A36RepairProblems',fld:'REPAIRPROBLEMS',pic:'9'},{av:'A25RepairDateTo',fld:'REPAIRDATETO',pic:''},{av:'A17GameName',fld:'GAMENAME',pic:''},{av:'A32RepairFinalCost',fld:'REPAIRFINALCOST',pic:'ZZZ9'},{av:'A28TechnicianName',fld:'TECHNICIANNAME',pic:''},{av:'A30RepairAlternateTechnicianName',fld:'REPAIRALTERNATETECHNICIANNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z22RepairId'},{av:'Z23RepairDateFrom'},{av:'Z24RepairDaysQuantity'},{av:'Z16GameId'},{av:'Z26RepairCost'},{av:'Z27TechnicianId'},{av:'Z29RepairAlternateTechnicianId'},{av:'Z31RepairDiscountPercentage'},{av:'Z36RepairProblems'},{av:'Z25RepairDateTo'},{av:'Z17GameName'},{av:'Z32RepairFinalCost'},{av:'Z28TechnicianName'},{av:'Z30RepairAlternateTechnicianName'},{av:'O36RepairProblems'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_REPAIRDATEFROM","{handler:'Valid_Repairdatefrom',iparms:[]");
         setEventMetadata("VALID_REPAIRDATEFROM",",oparms:[]}");
         setEventMetadata("VALID_REPAIRDAYSQUANTITY","{handler:'Valid_Repairdaysquantity',iparms:[]");
         setEventMetadata("VALID_REPAIRDAYSQUANTITY",",oparms:[]}");
         setEventMetadata("VALID_GAMEID","{handler:'Valid_Gameid',iparms:[{av:'A16GameId',fld:'GAMEID',pic:'ZZZ9'},{av:'A17GameName',fld:'GAMENAME',pic:''}]");
         setEventMetadata("VALID_GAMEID",",oparms:[{av:'A17GameName',fld:'GAMENAME',pic:''}]}");
         setEventMetadata("VALID_REPAIRCOST","{handler:'Valid_Repaircost',iparms:[]");
         setEventMetadata("VALID_REPAIRCOST",",oparms:[]}");
         setEventMetadata("VALID_TECHNICIANID","{handler:'Valid_Technicianid',iparms:[{av:'A27TechnicianId',fld:'TECHNICIANID',pic:'ZZZ9'},{av:'A28TechnicianName',fld:'TECHNICIANNAME',pic:''}]");
         setEventMetadata("VALID_TECHNICIANID",",oparms:[{av:'A28TechnicianName',fld:'TECHNICIANNAME',pic:''}]}");
         setEventMetadata("VALID_REPAIRALTERNATETECHNICIANID","{handler:'Valid_Repairalternatetechnicianid',iparms:[{av:'A29RepairAlternateTechnicianId',fld:'REPAIRALTERNATETECHNICIANID',pic:'ZZZ9'},{av:'A30RepairAlternateTechnicianName',fld:'REPAIRALTERNATETECHNICIANNAME',pic:''}]");
         setEventMetadata("VALID_REPAIRALTERNATETECHNICIANID",",oparms:[{av:'A30RepairAlternateTechnicianName',fld:'REPAIRALTERNATETECHNICIANNAME',pic:''}]}");
         setEventMetadata("VALID_REPAIRDISCOUNTPERCENTAGE","{handler:'Valid_Repairdiscountpercentage',iparms:[]");
         setEventMetadata("VALID_REPAIRDISCOUNTPERCENTAGE",",oparms:[]}");
         setEventMetadata("VALID_REPAIRKINDID","{handler:'Valid_Repairkindid',iparms:[]");
         setEventMetadata("VALID_REPAIRKINDID",",oparms:[]}");
         setEventMetadata("VALID_REPAIRKINDNAME","{handler:'Valid_Repairkindname',iparms:[]");
         setEventMetadata("VALID_REPAIRKINDNAME",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Repairkindremarks',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
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
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z23RepairDateFrom = DateTime.MinValue;
         Z37RepairKindName = "";
         Z35RepairKindRemarks = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A23RepairDateFrom = DateTime.MinValue;
         A25RepairDateTo = DateTime.MinValue;
         sImgUrl = "";
         A17GameName = "";
         A28TechnicianName = "";
         A30RepairAlternateTechnicianName = "";
         lblTitlekind_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridrepair_kindContainer = new GXWebGrid( context);
         Gridrepair_kindColumn = new GXWebColumn();
         A37RepairKindName = "";
         A35RepairKindRemarks = "";
         sMode9 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         Z17GameName = "";
         Z28TechnicianName = "";
         Z30RepairAlternateTechnicianName = "";
         T000612_A22RepairId = new short[1] ;
         T000612_A23RepairDateFrom = new DateTime[] {DateTime.MinValue} ;
         T000612_A24RepairDaysQuantity = new short[1] ;
         T000612_A17GameName = new string[] {""} ;
         T000612_A26RepairCost = new short[1] ;
         T000612_A28TechnicianName = new string[] {""} ;
         T000612_A30RepairAlternateTechnicianName = new string[] {""} ;
         T000612_A31RepairDiscountPercentage = new short[1] ;
         T000612_A16GameId = new short[1] ;
         T000612_A27TechnicianId = new short[1] ;
         T000612_A29RepairAlternateTechnicianId = new short[1] ;
         T000612_A36RepairProblems = new short[1] ;
         T000612_n36RepairProblems = new bool[] {false} ;
         T000610_A36RepairProblems = new short[1] ;
         T000610_n36RepairProblems = new bool[] {false} ;
         T00066_A17GameName = new string[] {""} ;
         T00067_A28TechnicianName = new string[] {""} ;
         T00068_A30RepairAlternateTechnicianName = new string[] {""} ;
         T000614_A36RepairProblems = new short[1] ;
         T000614_n36RepairProblems = new bool[] {false} ;
         T000615_A17GameName = new string[] {""} ;
         T000616_A28TechnicianName = new string[] {""} ;
         T000617_A30RepairAlternateTechnicianName = new string[] {""} ;
         T000618_A22RepairId = new short[1] ;
         T00065_A22RepairId = new short[1] ;
         T00065_A23RepairDateFrom = new DateTime[] {DateTime.MinValue} ;
         T00065_A24RepairDaysQuantity = new short[1] ;
         T00065_A26RepairCost = new short[1] ;
         T00065_A31RepairDiscountPercentage = new short[1] ;
         T00065_A16GameId = new short[1] ;
         T00065_A27TechnicianId = new short[1] ;
         T00065_A29RepairAlternateTechnicianId = new short[1] ;
         sMode7 = "";
         T000619_A22RepairId = new short[1] ;
         T000620_A22RepairId = new short[1] ;
         T00064_A22RepairId = new short[1] ;
         T00064_A23RepairDateFrom = new DateTime[] {DateTime.MinValue} ;
         T00064_A24RepairDaysQuantity = new short[1] ;
         T00064_A26RepairCost = new short[1] ;
         T00064_A31RepairDiscountPercentage = new short[1] ;
         T00064_A16GameId = new short[1] ;
         T00064_A27TechnicianId = new short[1] ;
         T00064_A29RepairAlternateTechnicianId = new short[1] ;
         T000621_A22RepairId = new short[1] ;
         T000625_A36RepairProblems = new short[1] ;
         T000625_n36RepairProblems = new bool[] {false} ;
         T000626_A17GameName = new string[] {""} ;
         T000627_A28TechnicianName = new string[] {""} ;
         T000628_A30RepairAlternateTechnicianName = new string[] {""} ;
         T000629_A22RepairId = new short[1] ;
         T000630_A22RepairId = new short[1] ;
         T000630_A33RepairKindId = new short[1] ;
         T000630_A37RepairKindName = new string[] {""} ;
         T000630_A35RepairKindRemarks = new string[] {""} ;
         T000631_A22RepairId = new short[1] ;
         T000631_A33RepairKindId = new short[1] ;
         T00063_A22RepairId = new short[1] ;
         T00063_A33RepairKindId = new short[1] ;
         T00063_A37RepairKindName = new string[] {""} ;
         T00063_A35RepairKindRemarks = new string[] {""} ;
         T00062_A22RepairId = new short[1] ;
         T00062_A33RepairKindId = new short[1] ;
         T00062_A37RepairKindName = new string[] {""} ;
         T00062_A35RepairKindRemarks = new string[] {""} ;
         T000635_A22RepairId = new short[1] ;
         T000635_A33RepairKindId = new short[1] ;
         Gridrepair_kindRow = new GXWebRow();
         subGridrepair_kind_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z25RepairDateTo = DateTime.MinValue;
         ZZ23RepairDateFrom = DateTime.MinValue;
         ZZ25RepairDateTo = DateTime.MinValue;
         ZZ17GameName = "";
         ZZ28TechnicianName = "";
         ZZ30RepairAlternateTechnicianName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.repair__default(),
            new Object[][] {
                new Object[] {
               T00062_A22RepairId, T00062_A33RepairKindId, T00062_A37RepairKindName, T00062_A35RepairKindRemarks
               }
               , new Object[] {
               T00063_A22RepairId, T00063_A33RepairKindId, T00063_A37RepairKindName, T00063_A35RepairKindRemarks
               }
               , new Object[] {
               T00064_A22RepairId, T00064_A23RepairDateFrom, T00064_A24RepairDaysQuantity, T00064_A26RepairCost, T00064_A31RepairDiscountPercentage, T00064_A16GameId, T00064_A27TechnicianId, T00064_A29RepairAlternateTechnicianId
               }
               , new Object[] {
               T00065_A22RepairId, T00065_A23RepairDateFrom, T00065_A24RepairDaysQuantity, T00065_A26RepairCost, T00065_A31RepairDiscountPercentage, T00065_A16GameId, T00065_A27TechnicianId, T00065_A29RepairAlternateTechnicianId
               }
               , new Object[] {
               T00066_A17GameName
               }
               , new Object[] {
               T00067_A28TechnicianName
               }
               , new Object[] {
               T00068_A30RepairAlternateTechnicianName
               }
               , new Object[] {
               T000610_A36RepairProblems, T000610_n36RepairProblems
               }
               , new Object[] {
               T000612_A22RepairId, T000612_A23RepairDateFrom, T000612_A24RepairDaysQuantity, T000612_A17GameName, T000612_A26RepairCost, T000612_A28TechnicianName, T000612_A30RepairAlternateTechnicianName, T000612_A31RepairDiscountPercentage, T000612_A16GameId, T000612_A27TechnicianId,
               T000612_A29RepairAlternateTechnicianId, T000612_A36RepairProblems, T000612_n36RepairProblems
               }
               , new Object[] {
               T000614_A36RepairProblems, T000614_n36RepairProblems
               }
               , new Object[] {
               T000615_A17GameName
               }
               , new Object[] {
               T000616_A28TechnicianName
               }
               , new Object[] {
               T000617_A30RepairAlternateTechnicianName
               }
               , new Object[] {
               T000618_A22RepairId
               }
               , new Object[] {
               T000619_A22RepairId
               }
               , new Object[] {
               T000620_A22RepairId
               }
               , new Object[] {
               T000621_A22RepairId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000625_A36RepairProblems, T000625_n36RepairProblems
               }
               , new Object[] {
               T000626_A17GameName
               }
               , new Object[] {
               T000627_A28TechnicianName
               }
               , new Object[] {
               T000628_A30RepairAlternateTechnicianName
               }
               , new Object[] {
               T000629_A22RepairId
               }
               , new Object[] {
               T000630_A22RepairId, T000630_A33RepairKindId, T000630_A37RepairKindName, T000630_A35RepairKindRemarks
               }
               , new Object[] {
               T000631_A22RepairId, T000631_A33RepairKindId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000635_A22RepairId, T000635_A33RepairKindId
               }
            }
         );
      }

      private short Z22RepairId ;
      private short Z24RepairDaysQuantity ;
      private short Z26RepairCost ;
      private short Z31RepairDiscountPercentage ;
      private short Z16GameId ;
      private short Z27TechnicianId ;
      private short Z29RepairAlternateTechnicianId ;
      private short O36RepairProblems ;
      private short Z33RepairKindId ;
      private short nRcdDeleted_9 ;
      private short nRcdExists_9 ;
      private short nIsMod_9 ;
      private short GxWebError ;
      private short A22RepairId ;
      private short A16GameId ;
      private short A27TechnicianId ;
      private short A29RepairAlternateTechnicianId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A24RepairDaysQuantity ;
      private short A26RepairCost ;
      private short A31RepairDiscountPercentage ;
      private short A32RepairFinalCost ;
      private short A36RepairProblems ;
      private short subGridrepair_kind_Backcolorstyle ;
      private short A33RepairKindId ;
      private short subGridrepair_kind_Allowselection ;
      private short subGridrepair_kind_Allowhovering ;
      private short subGridrepair_kind_Allowcollapsing ;
      private short subGridrepair_kind_Collapsed ;
      private short nBlankRcdCount9 ;
      private short RcdFound9 ;
      private short B36RepairProblems ;
      private short nBlankRcdUsr9 ;
      private short s36RepairProblems ;
      private short GX_JID ;
      private short Z36RepairProblems ;
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private short Gx_BScreen ;
      private short nIsDirty_9 ;
      private short subGridrepair_kind_Backstyle ;
      private short gxajaxcallmode ;
      private short Z32RepairFinalCost ;
      private short ZZ22RepairId ;
      private short ZZ24RepairDaysQuantity ;
      private short ZZ16GameId ;
      private short ZZ26RepairCost ;
      private short ZZ27TechnicianId ;
      private short ZZ29RepairAlternateTechnicianId ;
      private short ZZ31RepairDiscountPercentage ;
      private short ZZ36RepairProblems ;
      private short ZZ32RepairFinalCost ;
      private short ZO36RepairProblems ;
      private int nRC_GXsfl_108 ;
      private int nGXsfl_108_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtRepairId_Enabled ;
      private int edtRepairDateFrom_Enabled ;
      private int edtRepairDaysQuantity_Enabled ;
      private int edtRepairDateTo_Enabled ;
      private int edtGameId_Enabled ;
      private int imgprompt_16_Visible ;
      private int edtGameName_Enabled ;
      private int edtRepairCost_Enabled ;
      private int edtTechnicianId_Enabled ;
      private int imgprompt_27_Visible ;
      private int edtTechnicianName_Enabled ;
      private int edtRepairAlternateTechnicianId_Enabled ;
      private int imgprompt_29_Visible ;
      private int edtRepairAlternateTechnicianName_Enabled ;
      private int edtRepairDiscountPercentage_Enabled ;
      private int edtRepairFinalCost_Enabled ;
      private int edtRepairProblems_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtRepairKindId_Enabled ;
      private int edtRepairKindRemarks_Enabled ;
      private int subGridrepair_kind_Selectedindex ;
      private int subGridrepair_kind_Selectioncolor ;
      private int subGridrepair_kind_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridrepair_kind_Backcolor ;
      private int subGridrepair_kind_Allbackcolor ;
      private int defedtRepairKindId_Enabled ;
      private int idxLst ;
      private long GRIDREPAIR_KIND_nFirstRecordOnPage ;
      private string sPrefix ;
      private string Z37RepairKindName ;
      private string Z35RepairKindRemarks ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_108_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtRepairId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtRepairId_Jsonclick ;
      private string edtRepairDateFrom_Internalname ;
      private string edtRepairDateFrom_Jsonclick ;
      private string edtRepairDaysQuantity_Internalname ;
      private string edtRepairDaysQuantity_Jsonclick ;
      private string edtRepairDateTo_Internalname ;
      private string edtRepairDateTo_Jsonclick ;
      private string edtGameId_Internalname ;
      private string edtGameId_Jsonclick ;
      private string sImgUrl ;
      private string imgprompt_16_Internalname ;
      private string imgprompt_16_Link ;
      private string edtGameName_Internalname ;
      private string A17GameName ;
      private string edtGameName_Jsonclick ;
      private string edtRepairCost_Internalname ;
      private string edtRepairCost_Jsonclick ;
      private string edtTechnicianId_Internalname ;
      private string edtTechnicianId_Jsonclick ;
      private string imgprompt_27_Internalname ;
      private string imgprompt_27_Link ;
      private string edtTechnicianName_Internalname ;
      private string A28TechnicianName ;
      private string edtTechnicianName_Jsonclick ;
      private string edtRepairAlternateTechnicianId_Internalname ;
      private string edtRepairAlternateTechnicianId_Jsonclick ;
      private string imgprompt_29_Internalname ;
      private string imgprompt_29_Link ;
      private string edtRepairAlternateTechnicianName_Internalname ;
      private string A30RepairAlternateTechnicianName ;
      private string edtRepairAlternateTechnicianName_Jsonclick ;
      private string edtRepairDiscountPercentage_Internalname ;
      private string edtRepairDiscountPercentage_Jsonclick ;
      private string edtRepairFinalCost_Internalname ;
      private string edtRepairFinalCost_Jsonclick ;
      private string edtRepairProblems_Internalname ;
      private string edtRepairProblems_Jsonclick ;
      private string divKindtable_Internalname ;
      private string lblTitlekind_Internalname ;
      private string lblTitlekind_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridrepair_kind_Header ;
      private string A37RepairKindName ;
      private string A35RepairKindRemarks ;
      private string sMode9 ;
      private string edtRepairKindId_Internalname ;
      private string cmbRepairKindName_Internalname ;
      private string edtRepairKindRemarks_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z17GameName ;
      private string Z28TechnicianName ;
      private string Z30RepairAlternateTechnicianName ;
      private string sMode7 ;
      private string sGXsfl_108_fel_idx="0001" ;
      private string subGridrepair_kind_Class ;
      private string subGridrepair_kind_Linesclass ;
      private string ROClassString ;
      private string edtRepairKindId_Jsonclick ;
      private string cmbRepairKindName_Jsonclick ;
      private string edtRepairKindRemarks_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridrepair_kind_Internalname ;
      private string ZZ17GameName ;
      private string ZZ28TechnicianName ;
      private string ZZ30RepairAlternateTechnicianName ;
      private DateTime Z23RepairDateFrom ;
      private DateTime A23RepairDateFrom ;
      private DateTime A25RepairDateTo ;
      private DateTime Z25RepairDateTo ;
      private DateTime ZZ23RepairDateFrom ;
      private DateTime ZZ25RepairDateTo ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n36RepairProblems ;
      private bool bGXsfl_108_Refreshing=false ;
      private bool Gx_longc ;
      private GXWebGrid Gridrepair_kindContainer ;
      private GXWebRow Gridrepair_kindRow ;
      private GXWebColumn Gridrepair_kindColumn ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbRepairKindName ;
      private IDataStoreProvider pr_default ;
      private short[] T000612_A22RepairId ;
      private DateTime[] T000612_A23RepairDateFrom ;
      private short[] T000612_A24RepairDaysQuantity ;
      private string[] T000612_A17GameName ;
      private short[] T000612_A26RepairCost ;
      private string[] T000612_A28TechnicianName ;
      private string[] T000612_A30RepairAlternateTechnicianName ;
      private short[] T000612_A31RepairDiscountPercentage ;
      private short[] T000612_A16GameId ;
      private short[] T000612_A27TechnicianId ;
      private short[] T000612_A29RepairAlternateTechnicianId ;
      private short[] T000612_A36RepairProblems ;
      private bool[] T000612_n36RepairProblems ;
      private short[] T000610_A36RepairProblems ;
      private bool[] T000610_n36RepairProblems ;
      private string[] T00066_A17GameName ;
      private string[] T00067_A28TechnicianName ;
      private string[] T00068_A30RepairAlternateTechnicianName ;
      private short[] T000614_A36RepairProblems ;
      private bool[] T000614_n36RepairProblems ;
      private string[] T000615_A17GameName ;
      private string[] T000616_A28TechnicianName ;
      private string[] T000617_A30RepairAlternateTechnicianName ;
      private short[] T000618_A22RepairId ;
      private short[] T00065_A22RepairId ;
      private DateTime[] T00065_A23RepairDateFrom ;
      private short[] T00065_A24RepairDaysQuantity ;
      private short[] T00065_A26RepairCost ;
      private short[] T00065_A31RepairDiscountPercentage ;
      private short[] T00065_A16GameId ;
      private short[] T00065_A27TechnicianId ;
      private short[] T00065_A29RepairAlternateTechnicianId ;
      private short[] T000619_A22RepairId ;
      private short[] T000620_A22RepairId ;
      private short[] T00064_A22RepairId ;
      private DateTime[] T00064_A23RepairDateFrom ;
      private short[] T00064_A24RepairDaysQuantity ;
      private short[] T00064_A26RepairCost ;
      private short[] T00064_A31RepairDiscountPercentage ;
      private short[] T00064_A16GameId ;
      private short[] T00064_A27TechnicianId ;
      private short[] T00064_A29RepairAlternateTechnicianId ;
      private short[] T000621_A22RepairId ;
      private short[] T000625_A36RepairProblems ;
      private bool[] T000625_n36RepairProblems ;
      private string[] T000626_A17GameName ;
      private string[] T000627_A28TechnicianName ;
      private string[] T000628_A30RepairAlternateTechnicianName ;
      private short[] T000629_A22RepairId ;
      private short[] T000630_A22RepairId ;
      private short[] T000630_A33RepairKindId ;
      private string[] T000630_A37RepairKindName ;
      private string[] T000630_A35RepairKindRemarks ;
      private short[] T000631_A22RepairId ;
      private short[] T000631_A33RepairKindId ;
      private short[] T00063_A22RepairId ;
      private short[] T00063_A33RepairKindId ;
      private string[] T00063_A37RepairKindName ;
      private string[] T00063_A35RepairKindRemarks ;
      private short[] T00062_A22RepairId ;
      private short[] T00062_A33RepairKindId ;
      private string[] T00062_A37RepairKindName ;
      private string[] T00062_A35RepairKindRemarks ;
      private short[] T000635_A22RepairId ;
      private short[] T000635_A33RepairKindId ;
      private GXWebForm Form ;
   }

   public class repair__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new UpdateCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new ForEachCursor(def[29])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000612;
          prmT000612 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@TechnicianId",GXType.Int16,4,0)
          };
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0)
          };
          Object[] prmT000614;
          prmT000614 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000615;
          prmT000615 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@TechnicianId",GXType.Int16,4,0)
          };
          Object[] prmT000617;
          prmT000617 = new Object[] {
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0)
          };
          Object[] prmT000618;
          prmT000618 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000619;
          prmT000619 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000620;
          prmT000620 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000621;
          prmT000621 = new Object[] {
          new ParDef("@RepairDateFrom",GXType.Date,8,0) ,
          new ParDef("@RepairDaysQuantity",GXType.Int16,4,0) ,
          new ParDef("@RepairCost",GXType.Int16,4,0) ,
          new ParDef("@RepairDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@GameId",GXType.Int16,4,0) ,
          new ParDef("@TechnicianId",GXType.Int16,4,0) ,
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0)
          };
          Object[] prmT000622;
          prmT000622 = new Object[] {
          new ParDef("@RepairDateFrom",GXType.Date,8,0) ,
          new ParDef("@RepairDaysQuantity",GXType.Int16,4,0) ,
          new ParDef("@RepairCost",GXType.Int16,4,0) ,
          new ParDef("@RepairDiscountPercentage",GXType.Int16,3,0) ,
          new ParDef("@GameId",GXType.Int16,4,0) ,
          new ParDef("@TechnicianId",GXType.Int16,4,0) ,
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0) ,
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000623;
          prmT000623 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000629;
          prmT000629 = new Object[] {
          };
          Object[] prmT000630;
          prmT000630 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmT000631;
          prmT000631 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmT000632;
          prmT000632 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0) ,
          new ParDef("@RepairKindName",GXType.NChar,1,0) ,
          new ParDef("@RepairKindRemarks",GXType.NChar,120,0)
          };
          Object[] prmT000633;
          prmT000633 = new Object[] {
          new ParDef("@RepairKindName",GXType.NChar,1,0) ,
          new ParDef("@RepairKindRemarks",GXType.NChar,120,0) ,
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmT000634;
          prmT000634 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0) ,
          new ParDef("@RepairKindId",GXType.Int16,1,0)
          };
          Object[] prmT000635;
          prmT000635 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000625;
          prmT000625 = new Object[] {
          new ParDef("@RepairId",GXType.Int16,4,0)
          };
          Object[] prmT000626;
          prmT000626 = new Object[] {
          new ParDef("@GameId",GXType.Int16,4,0)
          };
          Object[] prmT000627;
          prmT000627 = new Object[] {
          new ParDef("@TechnicianId",GXType.Int16,4,0)
          };
          Object[] prmT000628;
          prmT000628 = new Object[] {
          new ParDef("@RepairAlternateTechnicianId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks] FROM [RepairRepairTransaction] WITH (UPDLOCK) WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks] FROM [RepairRepairTransaction] WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [RepairId], [RepairDateFrom], [RepairDaysQuantity], [RepairCost], [RepairDiscountPercentage], [GameId], [TechnicianId], [RepairAlternateTechnicianId] AS RepairAlternateTechnicianId FROM [Repair] WITH (UPDLOCK) WHERE [RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [RepairId], [RepairDateFrom], [RepairDaysQuantity], [RepairCost], [RepairDiscountPercentage], [GameId], [TechnicianId], [RepairAlternateTechnicianId] AS RepairAlternateTechnicianId FROM [Repair] WHERE [RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT [GameName] FROM [Game] WHERE [GameId] = @GameId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT [TechnicianName] FROM [Technician] WHERE [TechnicianId] = @TechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT [TechnicianName] AS RepairAlternateTechnicianName FROM [Technician] WHERE [TechnicianId] = @RepairAlternateTechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000610", "SELECT COALESCE( T1.[RepairProblems], 0) AS RepairProblems FROM (SELECT COUNT(*) AS RepairProblems, [RepairId] FROM [RepairRepairTransaction] WITH (UPDLOCK) GROUP BY [RepairId] ) T1 WHERE T1.[RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000612", "SELECT TM1.[RepairId], TM1.[RepairDateFrom], TM1.[RepairDaysQuantity], T3.[GameName], TM1.[RepairCost], T4.[TechnicianName], T5.[TechnicianName] AS RepairAlternateTechnicianName, TM1.[RepairDiscountPercentage], TM1.[GameId], TM1.[TechnicianId], TM1.[RepairAlternateTechnicianId] AS RepairAlternateTechnicianId, COALESCE( T2.[RepairProblems], 0) AS RepairProblems FROM (((([Repair] TM1 LEFT JOIN (SELECT COUNT(*) AS RepairProblems, [RepairId] FROM [RepairRepairTransaction] GROUP BY [RepairId] ) T2 ON T2.[RepairId] = TM1.[RepairId]) INNER JOIN [Game] T3 ON T3.[GameId] = TM1.[GameId]) INNER JOIN [Technician] T4 ON T4.[TechnicianId] = TM1.[TechnicianId]) INNER JOIN [Technician] T5 ON T5.[TechnicianId] = TM1.[RepairAlternateTechnicianId]) WHERE TM1.[RepairId] = @RepairId ORDER BY TM1.[RepairId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000614", "SELECT COALESCE( T1.[RepairProblems], 0) AS RepairProblems FROM (SELECT COUNT(*) AS RepairProblems, [RepairId] FROM [RepairRepairTransaction] WITH (UPDLOCK) GROUP BY [RepairId] ) T1 WHERE T1.[RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000615", "SELECT [GameName] FROM [Game] WHERE [GameId] = @GameId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000616", "SELECT [TechnicianName] FROM [Technician] WHERE [TechnicianId] = @TechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000617", "SELECT [TechnicianName] AS RepairAlternateTechnicianName FROM [Technician] WHERE [TechnicianId] = @RepairAlternateTechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000618", "SELECT [RepairId] FROM [Repair] WHERE [RepairId] = @RepairId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000619", "SELECT TOP 1 [RepairId] FROM [Repair] WHERE ( [RepairId] > @RepairId) ORDER BY [RepairId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000619,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000620", "SELECT TOP 1 [RepairId] FROM [Repair] WHERE ( [RepairId] < @RepairId) ORDER BY [RepairId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000620,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000621", "INSERT INTO [Repair]([RepairDateFrom], [RepairDaysQuantity], [RepairCost], [RepairDiscountPercentage], [GameId], [TechnicianId], [RepairAlternateTechnicianId]) VALUES(@RepairDateFrom, @RepairDaysQuantity, @RepairCost, @RepairDiscountPercentage, @GameId, @TechnicianId, @RepairAlternateTechnicianId); SELECT SCOPE_IDENTITY()", GxErrorMask.GX_NOMASK,prmT000621)
             ,new CursorDef("T000622", "UPDATE [Repair] SET [RepairDateFrom]=@RepairDateFrom, [RepairDaysQuantity]=@RepairDaysQuantity, [RepairCost]=@RepairCost, [RepairDiscountPercentage]=@RepairDiscountPercentage, [GameId]=@GameId, [TechnicianId]=@TechnicianId, [RepairAlternateTechnicianId]=@RepairAlternateTechnicianId  WHERE [RepairId] = @RepairId", GxErrorMask.GX_NOMASK,prmT000622)
             ,new CursorDef("T000623", "DELETE FROM [Repair]  WHERE [RepairId] = @RepairId", GxErrorMask.GX_NOMASK,prmT000623)
             ,new CursorDef("T000625", "SELECT COALESCE( T1.[RepairProblems], 0) AS RepairProblems FROM (SELECT COUNT(*) AS RepairProblems, [RepairId] FROM [RepairRepairTransaction] WITH (UPDLOCK) GROUP BY [RepairId] ) T1 WHERE T1.[RepairId] = @RepairId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000625,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000626", "SELECT [GameName] FROM [Game] WHERE [GameId] = @GameId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000626,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000627", "SELECT [TechnicianName] FROM [Technician] WHERE [TechnicianId] = @TechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000627,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000628", "SELECT [TechnicianName] AS RepairAlternateTechnicianName FROM [Technician] WHERE [TechnicianId] = @RepairAlternateTechnicianId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000628,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000629", "SELECT [RepairId] FROM [Repair] ORDER BY [RepairId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000629,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000630", "SELECT [RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks] FROM [RepairRepairTransaction] WHERE [RepairId] = @RepairId and [RepairKindId] = @RepairKindId ORDER BY [RepairId], [RepairKindId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000630,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000631", "SELECT [RepairId], [RepairKindId] FROM [RepairRepairTransaction] WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000631,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000632", "INSERT INTO [RepairRepairTransaction]([RepairId], [RepairKindId], [RepairKindName], [RepairKindRemarks]) VALUES(@RepairId, @RepairKindId, @RepairKindName, @RepairKindRemarks)", GxErrorMask.GX_NOMASK,prmT000632)
             ,new CursorDef("T000633", "UPDATE [RepairRepairTransaction] SET [RepairKindName]=@RepairKindName, [RepairKindRemarks]=@RepairKindRemarks  WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId", GxErrorMask.GX_NOMASK,prmT000633)
             ,new CursorDef("T000634", "DELETE FROM [RepairRepairTransaction]  WHERE [RepairId] = @RepairId AND [RepairKindId] = @RepairKindId", GxErrorMask.GX_NOMASK,prmT000634)
             ,new CursorDef("T000635", "SELECT [RepairId], [RepairKindId] FROM [RepairRepairTransaction] WHERE [RepairId] = @RepairId ORDER BY [RepairId], [RepairKindId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000635,11, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 29 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
