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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class acountrieslist : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("Carmine");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            toggleJsOutput = isJsOutputEnabled( );
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public acountrieslist( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("Carmine");
      }

      public acountrieslist( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         acountrieslist objacountrieslist;
         objacountrieslist = new acountrieslist();
         objacountrieslist.context.SetSubmitInitialConfig(context);
         objacountrieslist.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objacountrieslist);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acountrieslist)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0I0( false, 215) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "d4d7688f-9e48-47ed-8664-8ef95772c471", "", context.GetTheme( )), 208, Gx_line+83, 625, Gx_line+200) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 16, true, false, false, false, 0, 255, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Countries List", 333, Gx_line+50, 491, Gx_line+77, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+215);
            H0I0( false, 45) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Country", 208, Gx_line+17, 247, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawText("Quantity", 542, Gx_line+17, 584, Gx_line+31, 0+256, 0, 0, 0) ;
            getPrinter().GxDrawLine(200, Gx_line+33, 633, Gx_line+33, 1, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+45);
            /* Using cursor P000I3 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A12CountryId = P000I3_A12CountryId[0];
               n12CountryId = P000I3_n12CountryId[0];
               A19CityId = P000I3_A19CityId[0];
               n19CityId = P000I3_n19CityId[0];
               A13CountryName = P000I3_A13CountryName[0];
               A40000GXC1 = P000I3_A40000GXC1[0];
               n40000GXC1 = P000I3_n40000GXC1[0];
               A7AmusementParkId = P000I3_A7AmusementParkId[0];
               A13CountryName = P000I3_A13CountryName[0];
               A40000GXC1 = P000I3_A40000GXC1[0];
               n40000GXC1 = P000I3_n40000GXC1[0];
               AV8Quantity = (short)(A40000GXC1);
               H0I0( false, 65) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A13CountryName, "")), 208, Gx_line+17, 469, Gx_line+32, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV8Quantity), "ZZZ9")), 542, Gx_line+17, 600, Gx_line+32, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+65);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0I0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0I0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000I3_A12CountryId = new short[1] ;
         P000I3_n12CountryId = new bool[] {false} ;
         P000I3_A19CityId = new short[1] ;
         P000I3_n19CityId = new bool[] {false} ;
         P000I3_A13CountryName = new string[] {""} ;
         P000I3_A40000GXC1 = new int[1] ;
         P000I3_n40000GXC1 = new bool[] {false} ;
         P000I3_A7AmusementParkId = new short[1] ;
         A13CountryName = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.acountrieslist__default(),
            new Object[][] {
                new Object[] {
               P000I3_A12CountryId, P000I3_n12CountryId, P000I3_A19CityId, P000I3_n19CityId, P000I3_A13CountryName, P000I3_A40000GXC1, P000I3_n40000GXC1, P000I3_A7AmusementParkId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A12CountryId ;
      private short A19CityId ;
      private short A7AmusementParkId ;
      private short AV8Quantity ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A40000GXC1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A13CountryName ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n12CountryId ;
      private bool n19CityId ;
      private bool n40000GXC1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000I3_A12CountryId ;
      private bool[] P000I3_n12CountryId ;
      private short[] P000I3_A19CityId ;
      private bool[] P000I3_n19CityId ;
      private string[] P000I3_A13CountryName ;
      private int[] P000I3_A40000GXC1 ;
      private bool[] P000I3_n40000GXC1 ;
      private short[] P000I3_A7AmusementParkId ;
   }

   public class acountrieslist__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000I3;
          prmP000I3 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P000I3", "SELECT T1.[CountryId], T1.[CityId], T2.[CountryName], COALESCE( T3.[GXC1], 0) AS GXC1, T1.[AmusementParkId] FROM (([AmusementPark] T1 INNER JOIN [Country] T2 ON T2.[CountryId] = T1.[CountryId]) LEFT JOIN (SELECT COUNT(*) AS GXC1, [CountryId], [CityId] FROM [CountryCity] GROUP BY [CountryId], [CityId] ) T3 ON T3.[CountryId] = T1.[CountryId] AND T3.[CityId] = T1.[CityId]) ORDER BY T1.[AmusementParkId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I3,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 50);
                ((int[]) buf[5])[0] = rslt.getInt(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((short[]) buf[7])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
