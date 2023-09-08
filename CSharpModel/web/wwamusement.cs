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
   public class wwamusement : GXDataArea, System.Web.SessionState.IRequiresSessionState
   {
      public wwamusement( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public wwamusement( IGxContext context )
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
         dynavCountryid = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxCallCrl"+"_"+"vCOUNTRYID") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               GXDLVvCOUNTRYID0S2( ) ;
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               nRC_GXsfl_24 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_24"), "."));
               nGXsfl_24_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_24_idx"), "."));
               sGXsfl_24_idx = GetPar( "sGXsfl_24_idx");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxnrGrid1_newrow( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               dynavCountryid.FromJSonString( GetNextPar( ));
               AV7CountryId = (short)(NumberUtil.Val( GetPar( "CountryId"), "."));
               AV5AmusementFrom = GetPar( "AmusementFrom");
               AV6AmusementTo = GetPar( "AmusementTo");
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxgrGrid1_refresh( AV7CountryId, AV5AmusementFrom, AV6AmusementTo) ;
               AddString( context.getJSONResponse( )) ;
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA0S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0S2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 182860), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 182860), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202362013201632", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwamusement.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCOUNTRYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CountryId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vAMUSEMENTFROM", StringUtil.RTrim( AV5AmusementFrom));
         GxWebStd.gx_hidden_field( context, "GXH_vAMUSEMENTTO", StringUtil.RTrim( AV6AmusementTo));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_24", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_24), 8, 0, ".", "")));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0S2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwamusement.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWAmusement" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWAmusement" ;
      }

      protected void WB0S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+dynavCountryid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, dynavCountryid_Internalname, "Country Id", "col-sm-3 AttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'" + sGXsfl_24_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, dynavCountryid, dynavCountryid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV7CountryId), 4, 0)), 1, dynavCountryid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, dynavCountryid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,8);\"", "", true, 1, "HLP_WWAmusement.htm");
            dynavCountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7CountryId), 4, 0));
            AssignProp("", false, dynavCountryid_Internalname, "Values", (string)(dynavCountryid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            wb_table1_11_0S2( true) ;
         }
         else
         {
            wb_table1_11_0S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_11_0S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"24\">") ;
               sStyleString = "";
               GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
               /* Subfile titles */
               context.WriteHtmlText( "<tr") ;
               context.WriteHtmlTextNl( ">") ;
               if ( subGrid1_Backcolorstyle == 0 )
               {
                  subGrid1_Titlebackstyle = 0;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
               else
               {
                  subGrid1_Titlebackstyle = 1;
                  if ( subGrid1_Backcolorstyle == 1 )
                  {
                     subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                     }
                  }
                  else
                  {
                     if ( StringUtil.Len( subGrid1_Class) > 0 )
                     {
                        subGrid1_Linesclass = subGrid1_Class+"Title";
                     }
                  }
               }
               context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Amusement Id") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Amusement Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Country Name") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Amusement Address") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
               context.SendWebValue( "Photo") ;
               context.WriteHtmlTextNl( "</th>") ;
               context.WriteHtmlTextNl( "</tr>") ;
               Grid1Container.AddObjectProperty("GridName", "Grid1");
            }
            else
            {
               if ( isAjaxCallMode( ) )
               {
                  Grid1Container = new GXWebGrid( context);
               }
               else
               {
                  Grid1Container.Clear();
               }
               Grid1Container.SetWrapped(nGXWrapped);
               Grid1Container.AddObjectProperty("GridName", "Grid1");
               Grid1Container.AddObjectProperty("Header", subGrid1_Header);
               Grid1Container.AddObjectProperty("Class", "Grid");
               Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("CmpContext", "");
               Grid1Container.AddObjectProperty("InMasterPage", "false");
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A8AmusementParkName));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A13CountryName));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", A10AmusementParkAddress);
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
               Grid1Column.AddObjectProperty("Value", context.convertURL( A11AmusementParkPhoto));
               Grid1Container.AddColumnProperties(Grid1Column);
               Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
               Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
               Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
            }
         }
         if ( wbEnd == 24 )
         {
            wbEnd = 0;
            nRC_GXsfl_24 = (int)(nGXsfl_24_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 24 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET Framework 17_0_8-158023", 0) ;
            }
            Form.Meta.addItem("description", "WWAmusement", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0S0( ) ;
      }

      protected void WS0S2( )
      {
         START0S2( ) ;
         EVT0S2( ) ;
      }

      protected void EVT0S2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_24_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
                              SubsflControlProps_242( ) ;
                              A7AmusementParkId = (short)(context.localUtil.CToN( cgiGet( edtAmusementParkId_Internalname), ".", ","));
                              A8AmusementParkName = cgiGet( edtAmusementParkName_Internalname);
                              A13CountryName = cgiGet( edtCountryName_Internalname);
                              A10AmusementParkAddress = cgiGet( edtAmusementParkAddress_Internalname);
                              A11AmusementParkPhoto = cgiGet( edtAmusementParkPhoto_Internalname);
                              AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_24_Refreshing);
                              AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E110S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Countryid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCOUNTRYID"), ".", ",") != Convert.ToDecimal( AV7CountryId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Amusementfrom Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vAMUSEMENTFROM"), AV5AmusementFrom) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Amusementto Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vAMUSEMENTTO"), AV6AmusementTo) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0S2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = dynavCountryid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void GXDLVvCOUNTRYID0S2( )
      {
         if ( ! context.isAjaxRequest( ) )
         {
            context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
         }
         AddString( "[[") ;
         GXDLVvCOUNTRYID_data0S2( ) ;
         gxdynajaxindex = 1;
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            AddString( gxwrpcisep+"{\"c\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)))+"\",\"d\":\""+GXUtil.EncodeJSConstant( ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)))+"\"}") ;
            gxdynajaxindex = (int)(gxdynajaxindex+1);
            gxwrpcisep = ",";
         }
         AddString( "]") ;
         if ( gxdynajaxctrlcodr.Count == 0 )
         {
            AddString( ",101") ;
         }
         AddString( "]") ;
      }

      protected void GXVvCOUNTRYID_html0S2( )
      {
         short gxdynajaxvalue;
         GXDLVvCOUNTRYID_data0S2( ) ;
         gxdynajaxindex = 1;
         if ( ! ( gxdyncontrolsrefreshing && context.isAjaxRequest( ) ) )
         {
            dynavCountryid.removeAllItems();
         }
         while ( gxdynajaxindex <= gxdynajaxctrlcodr.Count )
         {
            gxdynajaxvalue = (short)(NumberUtil.Val( ((string)gxdynajaxctrlcodr.Item(gxdynajaxindex)), "."));
            dynavCountryid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(gxdynajaxvalue), 4, 0)), ((string)gxdynajaxctrldescr.Item(gxdynajaxindex)), 0);
            gxdynajaxindex = (int)(gxdynajaxindex+1);
         }
      }

      protected void GXDLVvCOUNTRYID_data0S2( )
      {
         gxdynajaxctrlcodr.Clear();
         gxdynajaxctrldescr.Clear();
         gxdynajaxctrlcodr.Add(StringUtil.Str( (decimal)(0), 1, 0));
         gxdynajaxctrldescr.Add("select");
         /* Using cursor H000S2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            gxdynajaxctrlcodr.Add(StringUtil.LTrim( StringUtil.NToC( (decimal)(H000S2_A12CountryId[0]), 4, 0, ".", "")));
            gxdynajaxctrldescr.Add(StringUtil.RTrim( H000S2_A13CountryName[0]));
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_242( ) ;
         while ( nGXsfl_24_idx <= nRC_GXsfl_24 )
         {
            sendrow_242( ) ;
            nGXsfl_24_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
            sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
            SubsflControlProps_242( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( short AV7CountryId ,
                                        string AV5AmusementFrom ,
                                        string AV6AmusementTo )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AMUSEMENTPARKID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "AMUSEMENTPARKID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            GXVvCOUNTRYID_html0S2( ) ;
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( dynavCountryid.ItemCount > 0 )
         {
            AV7CountryId = (short)(NumberUtil.Val( dynavCountryid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV7CountryId), 4, 0))), "."));
            AssignAttri("", false, "AV7CountryId", StringUtil.LTrimStr( (decimal)(AV7CountryId), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            dynavCountryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV7CountryId), 4, 0));
            AssignProp("", false, dynavCountryid_Internalname, "Values", dynavCountryid.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 24;
         nGXsfl_24_idx = 1;
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         bGXsfl_24_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "Grid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_242( ) ;
            pr_default.dynParam(1, new Object[]{ new Object[]{
                                                 AV7CountryId ,
                                                 AV5AmusementFrom ,
                                                 AV6AmusementTo ,
                                                 A12CountryId ,
                                                 A8AmusementParkName } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor H000S3 */
            pr_default.execute(1, new Object[] {AV7CountryId, AV5AmusementFrom, AV6AmusementTo});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A12CountryId = H000S3_A12CountryId[0];
               A40000AmusementParkPhoto_GXI = H000S3_A40000AmusementParkPhoto_GXI[0];
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_24_Refreshing);
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
               A10AmusementParkAddress = H000S3_A10AmusementParkAddress[0];
               A13CountryName = H000S3_A13CountryName[0];
               A8AmusementParkName = H000S3_A8AmusementParkName[0];
               A7AmusementParkId = H000S3_A7AmusementParkId[0];
               A11AmusementParkPhoto = H000S3_A11AmusementParkPhoto[0];
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A11AmusementParkPhoto))), !bGXsfl_24_Refreshing);
               AssignProp("", false, edtAmusementParkPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A11AmusementParkPhoto), true);
               A13CountryName = H000S3_A13CountryName[0];
               /* Execute user event: Load */
               E110S2 ();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            wbEnd = 24;
            WB0S0( ) ;
         }
         bGXsfl_24_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0S2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_AMUSEMENTPARKID"+"_"+sGXsfl_24_idx, GetSecureSignedToken( sGXsfl_24_idx, context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         GXVvCOUNTRYID_html0S2( ) ;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_24 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_24"), ".", ","));
            /* Read variables values. */
            dynavCountryid.Name = dynavCountryid_Internalname;
            dynavCountryid.CurrentValue = cgiGet( dynavCountryid_Internalname);
            AV7CountryId = (short)(NumberUtil.Val( cgiGet( dynavCountryid_Internalname), "."));
            AssignAttri("", false, "AV7CountryId", StringUtil.LTrimStr( (decimal)(AV7CountryId), 4, 0));
            AV5AmusementFrom = cgiGet( edtavAmusementfrom_Internalname);
            AssignAttri("", false, "AV5AmusementFrom", AV5AmusementFrom);
            AV6AmusementTo = cgiGet( edtavAmusementto_Internalname);
            AssignAttri("", false, "AV6AmusementTo", AV6AmusementTo);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      private void E110S2( )
      {
         /* Load Routine */
         returnInSub = false;
         sendrow_242( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_24_Refreshing )
         {
            context.DoAjaxLoad(24, Grid1Row);
         }
      }

      protected void wb_table1_11_0S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavAmusementfrom_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAmusementfrom_Internalname, "Amusement Park Name", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAmusementfrom_Internalname, StringUtil.RTrim( AV5AmusementFrom), StringUtil.RTrim( context.localUtil.Format( AV5AmusementFrom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAmusementfrom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAmusementfrom_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWAmusement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "left", "top", ""+" data-gx-for=\""+edtavAmusementto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAmusementto_Internalname, "Amusement Park Name", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'" + sGXsfl_24_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAmusementto_Internalname, StringUtil.RTrim( AV6AmusementTo), StringUtil.RTrim( context.localUtil.Format( AV6AmusementTo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,21);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAmusementto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavAmusementto_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWAmusement.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_11_0S2e( true) ;
         }
         else
         {
            wb_table1_11_0S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0S2( ) ;
         WS0S2( ) ;
         WE0S2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202362013201657", true, true);
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
         context.AddJavascriptSource("wwamusement.js", "?202362013201657", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_242( )
      {
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID_"+sGXsfl_24_idx;
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME_"+sGXsfl_24_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_24_idx;
         edtAmusementParkAddress_Internalname = "AMUSEMENTPARKADDRESS_"+sGXsfl_24_idx;
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO_"+sGXsfl_24_idx;
      }

      protected void SubsflControlProps_fel_242( )
      {
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID_"+sGXsfl_24_fel_idx;
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME_"+sGXsfl_24_fel_idx;
         edtCountryName_Internalname = "COUNTRYNAME_"+sGXsfl_24_fel_idx;
         edtAmusementParkAddress_Internalname = "AMUSEMENTPARKADDRESS_"+sGXsfl_24_fel_idx;
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO_"+sGXsfl_24_fel_idx;
      }

      protected void sendrow_242( )
      {
         SubsflControlProps_242( ) ;
         WB0S0( ) ;
         Grid1Row = GXWebRow.GetNew(context,Grid1Container);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0x0);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_24_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_24_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A7AmusementParkId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A7AmusementParkId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmusementParkId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkName_Internalname,StringUtil.RTrim( A8AmusementParkName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+"e120s2_client"+"'",(string)"",(string)"",(string)"",(string)"",(string)edtAmusementParkName_Jsonclick,(short)7,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCountryName_Internalname,StringUtil.RTrim( A13CountryName),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCountryName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)-1,(bool)true,(string)"Name",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkAddress_Internalname,(string)A10AmusementParkAddress,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A10AmusementParkAddress),(string)"_blank",(string)"",(string)"",(string)edtAmusementParkAddress_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)24,(short)1,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A11AmusementParkPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000AmusementParkPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A11AmusementParkPhoto)) ? A40000AmusementParkPhoto_GXI : context.PathToRelativeUrl( A11AmusementParkPhoto));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtAmusementParkPhoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)1,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A11AmusementParkPhoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         send_integrity_lvl_hashes0S2( ) ;
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_24_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_24_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_24_idx+1);
         sGXsfl_24_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_24_idx), 4, 0), 4, "0");
         SubsflControlProps_242( ) ;
         /* End function sendrow_242 */
      }

      protected void init_web_controls( )
      {
         dynavCountryid.Name = "vCOUNTRYID";
         dynavCountryid.WebTags = "";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         dynavCountryid_Internalname = "vCOUNTRYID";
         edtavAmusementfrom_Internalname = "vAMUSEMENTFROM";
         edtavAmusementto_Internalname = "vAMUSEMENTTO";
         tblTable1_Internalname = "TABLE1";
         edtAmusementParkId_Internalname = "AMUSEMENTPARKID";
         edtAmusementParkName_Internalname = "AMUSEMENTPARKNAME";
         edtCountryName_Internalname = "COUNTRYNAME";
         edtAmusementParkAddress_Internalname = "AMUSEMENTPARKADDRESS";
         edtAmusementParkPhoto_Internalname = "AMUSEMENTPARKPHOTO";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("Carmine");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtAmusementParkAddress_Jsonclick = "";
         edtCountryName_Jsonclick = "";
         edtAmusementParkName_Jsonclick = "";
         edtAmusementParkId_Jsonclick = "";
         edtavAmusementto_Jsonclick = "";
         edtavAmusementto_Enabled = 1;
         edtavAmusementfrom_Jsonclick = "";
         edtavAmusementfrom_Enabled = 1;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         subGrid1_Class = "Grid";
         subGrid1_Backcolorstyle = 0;
         dynavCountryid_Jsonclick = "";
         dynavCountryid.Enabled = 1;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "WWAmusement";
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'AV5AmusementFrom',fld:'vAMUSEMENTFROM',pic:''},{av:'AV6AmusementTo',fld:'vAMUSEMENTTO',pic:''},{av:'dynavCountryid'},{av:'AV7CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'dynavCountryid'},{av:'AV7CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]}");
         setEventMetadata("AMUSEMENTPARKNAME.CLICK","{handler:'E120S2',iparms:[{av:'A7AmusementParkId',fld:'AMUSEMENTPARKID',pic:'ZZZ9',hsh:true},{av:'dynavCountryid'},{av:'AV7CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("AMUSEMENTPARKNAME.CLICK",",oparms:[{av:'dynavCountryid'},{av:'AV7CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Valid_Amusementparkphoto',iparms:[{av:'dynavCountryid'},{av:'AV7CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]");
         setEventMetadata("NULL",",oparms:[{av:'dynavCountryid'},{av:'AV7CountryId',fld:'vCOUNTRYID',pic:'ZZZ9'}]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV5AmusementFrom = "";
         AV6AmusementTo = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         subGrid1_Linesclass = "";
         Grid1Column = new GXWebColumn();
         A8AmusementParkName = "";
         A13CountryName = "";
         A10AmusementParkAddress = "";
         A11AmusementParkPhoto = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A40000AmusementParkPhoto_GXI = "";
         gxdynajaxctrlcodr = new GeneXus.Utils.GxStringCollection();
         gxdynajaxctrldescr = new GeneXus.Utils.GxStringCollection();
         gxwrpcisep = "";
         scmdbuf = "";
         H000S2_A12CountryId = new short[1] ;
         H000S2_A13CountryName = new string[] {""} ;
         H000S3_A12CountryId = new short[1] ;
         H000S3_A40000AmusementParkPhoto_GXI = new string[] {""} ;
         H000S3_A10AmusementParkAddress = new string[] {""} ;
         H000S3_A13CountryName = new string[] {""} ;
         H000S3_A8AmusementParkName = new string[] {""} ;
         H000S3_A7AmusementParkId = new short[1] ;
         H000S3_A11AmusementParkPhoto = new string[] {""} ;
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwamusement__default(),
            new Object[][] {
                new Object[] {
               H000S2_A12CountryId, H000S2_A13CountryName
               }
               , new Object[] {
               H000S3_A12CountryId, H000S3_A40000AmusementParkPhoto_GXI, H000S3_A10AmusementParkAddress, H000S3_A13CountryName, H000S3_A8AmusementParkName, H000S3_A7AmusementParkId, H000S3_A11AmusementParkPhoto
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV7CountryId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Titlebackstyle ;
      private short A7AmusementParkId ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short A12CountryId ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short GRID1_nEOF ;
      private int nRC_GXsfl_24 ;
      private int nGXsfl_24_idx=1 ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int gxdynajaxindex ;
      private int subGrid1_Islastpage ;
      private int edtavAmusementfrom_Enabled ;
      private int edtavAmusementto_Enabled ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_24_idx="0001" ;
      private string AV5AmusementFrom ;
      private string AV6AmusementTo ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string dynavCountryid_Internalname ;
      private string TempTags ;
      private string dynavCountryid_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string subGrid1_Header ;
      private string A8AmusementParkName ;
      private string A13CountryName ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtAmusementParkId_Internalname ;
      private string edtAmusementParkName_Internalname ;
      private string edtCountryName_Internalname ;
      private string edtAmusementParkAddress_Internalname ;
      private string edtAmusementParkPhoto_Internalname ;
      private string gxwrpcisep ;
      private string scmdbuf ;
      private string edtavAmusementfrom_Internalname ;
      private string edtavAmusementto_Internalname ;
      private string tblTable1_Internalname ;
      private string edtavAmusementfrom_Jsonclick ;
      private string edtavAmusementto_Jsonclick ;
      private string sGXsfl_24_fel_idx="0001" ;
      private string ROClassString ;
      private string edtAmusementParkId_Jsonclick ;
      private string edtAmusementParkName_Jsonclick ;
      private string edtCountryName_Jsonclick ;
      private string edtAmusementParkAddress_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_24_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A11AmusementParkPhoto_IsBlob ;
      private string A10AmusementParkAddress ;
      private string A40000AmusementParkPhoto_GXI ;
      private string A11AmusementParkPhoto ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrlcodr ;
      private GeneXus.Utils.GxStringCollection gxdynajaxctrldescr ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private GXCombobox dynavCountryid ;
      private IDataStoreProvider pr_default ;
      private short[] H000S2_A12CountryId ;
      private string[] H000S2_A13CountryName ;
      private short[] H000S3_A12CountryId ;
      private string[] H000S3_A40000AmusementParkPhoto_GXI ;
      private string[] H000S3_A10AmusementParkAddress ;
      private string[] H000S3_A13CountryName ;
      private string[] H000S3_A8AmusementParkName ;
      private short[] H000S3_A7AmusementParkId ;
      private string[] H000S3_A11AmusementParkPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class wwamusement__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000S3( IGxContext context ,
                                             short AV7CountryId ,
                                             string AV5AmusementFrom ,
                                             string AV6AmusementTo ,
                                             short A12CountryId ,
                                             string A8AmusementParkName )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CountryId], T1.[AmusementParkPhoto_GXI], T1.[AmusementParkAddress], T2.[CountryName], T1.[AmusementParkName], T1.[AmusementParkId], T1.[AmusementParkPhoto] FROM ([AmusementPark] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId])";
         if ( ! (0==AV7CountryId) )
         {
            AddWhere(sWhereString, "(T1.[CountryId] = @AV7CountryId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV5AmusementFrom)) )
         {
            AddWhere(sWhereString, "(T1.[AmusementParkName] >= @AV5AmusementFrom)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV6AmusementTo)) )
         {
            AddWhere(sWhereString, "(T1.[AmusementParkName] <= @AV6AmusementTo)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[AmusementParkName]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 1 :
                     return conditional_H000S3(context, (short)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000S2;
          prmH000S2 = new Object[] {
          };
          Object[] prmH000S3;
          prmH000S3 = new Object[] {
          new ParDef("@AV7CountryId",GXType.Int16,4,0) ,
          new ParDef("@AV5AmusementFrom",GXType.Char,20,0) ,
          new ParDef("@AV6AmusementTo",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000S2", "SELECT [CountryId], [CountryName] FROM [Country] ORDER BY [CountryName] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000S2,0, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000S3,11, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 50);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 50);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaFile(7, rslt.getVarchar(2));
                return;
       }
    }

 }

}
