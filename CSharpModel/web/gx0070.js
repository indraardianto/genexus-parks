gx.evt.autoSkip=!1;gx.define("gx0070",!1,function(){var n,t;this.ServerClass="gx0070";this.PackageName="GeneXus.Programs";this.ServerFullClass="gx0070.aspx";this.setObjectType("web");this.anyGridBaseTable=!0;this.hasEnterEvent=!0;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.AV13pRepairId=gx.fn.getIntegerValue("vPREPAIRID",",")};this.Validv_Crepairdatefrom=function(){return this.validCliEvt("Validv_Crepairdatefrom",0,function(){try{var n=gx.util.balloon.getNew("vCREPAIRDATEFROM");if(this.AnyError=0,!(new gx.date.gxdate("").compare(this.AV7cRepairDateFrom)===0||new gx.date.gxdate(this.AV7cRepairDateFrom).compare(gx.date.ymdtod(1753,1,1))>=0))try{n.setError("Field Repair Date From is out of range");this.AnyError=gx.num.trunc(1,0)}catch(t){}}catch(t){}try{return n==null?!0:n.show()}catch(t){}return!0})};this.e180q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class"),"AdvancedContainer")==0?(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer AdvancedContainerVisible"),gx.fn.setCtrlProperty("BTNTOGGLE","Class",gx.fn.getCtrlProperty("BTNTOGGLE","Class")+" BtnToggleActive")):(gx.fn.setCtrlProperty("ADVANCEDCONTAINER","Class","AdvancedContainer"),gx.fn.setCtrlProperty("BTNTOGGLE","Class","BtnToggle")),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e110q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("REPAIRIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("REPAIRIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCREPAIRID","Visible",!0)):(gx.fn.setCtrlProperty("REPAIRIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCREPAIRID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("REPAIRIDFILTERCONTAINER","Class")',ctrl:"REPAIRIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCREPAIRID","Visible")',ctrl:"vCREPAIRID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e120q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("REPAIRDATEFROMFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?gx.fn.setCtrlProperty("REPAIRDATEFROMFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"):gx.fn.setCtrlProperty("REPAIRDATEFROMFILTERCONTAINER","Class","AdvancedContainerItem"),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("REPAIRDATEFROMFILTERCONTAINER","Class")',ctrl:"REPAIRDATEFROMFILTERCONTAINER",prop:"Class"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e130q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("REPAIRDAYSQUANTITYFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("REPAIRDAYSQUANTITYFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCREPAIRDAYSQUANTITY","Visible",!0)):(gx.fn.setCtrlProperty("REPAIRDAYSQUANTITYFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCREPAIRDAYSQUANTITY","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("REPAIRDAYSQUANTITYFILTERCONTAINER","Class")',ctrl:"REPAIRDAYSQUANTITYFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCREPAIRDAYSQUANTITY","Visible")',ctrl:"vCREPAIRDAYSQUANTITY",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e140q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("GAMEIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("GAMEIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCGAMEID","Visible",!0)):(gx.fn.setCtrlProperty("GAMEIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCGAMEID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("GAMEIDFILTERCONTAINER","Class")',ctrl:"GAMEIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCGAMEID","Visible")',ctrl:"vCGAMEID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e150q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("REPAIRCOSTFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("REPAIRCOSTFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCREPAIRCOST","Visible",!0)):(gx.fn.setCtrlProperty("REPAIRCOSTFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCREPAIRCOST","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("REPAIRCOSTFILTERCONTAINER","Class")',ctrl:"REPAIRCOSTFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCREPAIRCOST","Visible")',ctrl:"vCREPAIRCOST",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e160q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("TECHNICIANIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("TECHNICIANIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCTECHNICIANID","Visible",!0)):(gx.fn.setCtrlProperty("TECHNICIANIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCTECHNICIANID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("TECHNICIANIDFILTERCONTAINER","Class")',ctrl:"TECHNICIANIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTECHNICIANID","Visible")',ctrl:"vCTECHNICIANID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e170q1_client=function(){return this.clearMessages(),gx.text.compare(gx.fn.getCtrlProperty("REPAIRALTERNATETECHNICIANIDFILTERCONTAINER","Class"),"AdvancedContainerItem")==0?(gx.fn.setCtrlProperty("REPAIRALTERNATETECHNICIANIDFILTERCONTAINER","Class","AdvancedContainerItem AdvancedContainerItemExpanded"),gx.fn.setCtrlProperty("vCREPAIRALTERNATETECHNICIANID","Visible",!0)):(gx.fn.setCtrlProperty("REPAIRALTERNATETECHNICIANIDFILTERCONTAINER","Class","AdvancedContainerItem"),gx.fn.setCtrlProperty("vCREPAIRALTERNATETECHNICIANID","Visible",!1)),this.refreshOutputs([{av:'gx.fn.getCtrlProperty("REPAIRALTERNATETECHNICIANIDFILTERCONTAINER","Class")',ctrl:"REPAIRALTERNATETECHNICIANIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCREPAIRALTERNATETECHNICIANID","Visible")',ctrl:"vCREPAIRALTERNATETECHNICIANID",prop:"Visible"}]),this.OnClientEventEnd(),gx.$.Deferred().resolve()};this.e210q2_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e220q1_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,85,86,87,88,89,90,91,92,93,94,95];this.GXLastCtrlId=95;this.Grid1Container=new gx.grid.grid(this,2,"WbpLvl2",84,"Grid1","Grid1","Grid1Container",this.CmpContext,this.IsMasterPage,"gx0070",[],!1,1,!1,!0,10,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);t=this.Grid1Container;t.addBitmap("&Linkselection","vLINKSELECTION",85,0,"px",17,"px",null,"","","SelectionAttribute","WWActionColumn");t.addSingleLineEdit(22,86,"REPAIRID","Id","","RepairId","int",0,"px",4,4,"right",null,[],22,"RepairId",!0,0,!1,!1,"Attribute",1,"WWColumn");t.addSingleLineEdit(23,87,"REPAIRDATEFROM","Date From","","RepairDateFrom","date",0,"px",8,8,"right",null,[],23,"RepairDateFrom",!0,0,!1,!1,"DescriptionAttribute",1,"WWColumn");t.addSingleLineEdit(24,88,"REPAIRDAYSQUANTITY","Days Quantity","","RepairDaysQuantity","int",0,"px",4,4,"right",null,[],24,"RepairDaysQuantity",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(16,89,"GAMEID","Game Id","","GameId","int",0,"px",4,4,"right",null,[],16,"GameId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(26,90,"REPAIRCOST","Cost","","RepairCost","int",0,"px",4,4,"right",null,[],26,"RepairCost",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(27,91,"TECHNICIANID","Technician Id","","TechnicianId","int",0,"px",4,4,"right",null,[],27,"TechnicianId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");t.addSingleLineEdit(29,92,"REPAIRALTERNATETECHNICIANID","Technician Id","","RepairAlternateTechnicianId","int",0,"px",4,4,"right",null,[],29,"RepairAlternateTechnicianId",!0,0,!1,!1,"Attribute",1,"WWColumn OptionalColumn");this.Grid1Container.emptyText="";this.setGrid(t);n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAIN",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"ADVANCEDCONTAINER",grid:0};n[7]={id:7,fld:"",grid:0};n[8]={id:8,fld:"",grid:0};n[9]={id:9,fld:"REPAIRIDFILTERCONTAINER",grid:0};n[10]={id:10,fld:"",grid:0};n[11]={id:11,fld:"",grid:0};n[12]={id:12,fld:"LBLREPAIRIDFILTER",format:1,grid:0,evt:"e110q1_client",ctrltype:"textblock"};n[13]={id:13,fld:"",grid:0};n[14]={id:14,fld:"",grid:0};n[15]={id:15,fld:"",grid:0};n[16]={id:16,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCREPAIRID",gxz:"ZV6cRepairId",gxold:"OV6cRepairId",gxvar:"AV6cRepairId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV6cRepairId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV6cRepairId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCREPAIRID",gx.O.AV6cRepairId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV6cRepairId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCREPAIRID",",")},nac:gx.falseFn};n[17]={id:17,fld:"",grid:0};n[18]={id:18,fld:"",grid:0};n[19]={id:19,fld:"REPAIRDATEFROMFILTERCONTAINER",grid:0};n[20]={id:20,fld:"",grid:0};n[21]={id:21,fld:"",grid:0};n[22]={id:22,fld:"LBLREPAIRDATEFROMFILTER",format:1,grid:0,evt:"e120q1_client",ctrltype:"textblock"};n[23]={id:23,fld:"",grid:0};n[24]={id:24,fld:"",grid:0};n[25]={id:25,fld:"",grid:0};n[26]={id:26,lvl:0,type:"date",len:8,dec:0,sign:!1,ro:0,grid:0,gxgrid:null,fnc:this.Validv_Crepairdatefrom,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCREPAIRDATEFROM",gxz:"ZV7cRepairDateFrom",gxold:"OV7cRepairDateFrom",gxvar:"AV7cRepairDateFrom",dp:{f:-1,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[26],ip:[26],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV7cRepairDateFrom=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.ZV7cRepairDateFrom=gx.fn.toDatetimeValue(n))},v2c:function(){gx.fn.setControlValue("vCREPAIRDATEFROM",gx.O.AV7cRepairDateFrom,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV7cRepairDateFrom=gx.fn.toDatetimeValue(this.val()))},val:function(){return gx.fn.getControlValue("vCREPAIRDATEFROM")},nac:gx.falseFn};n[27]={id:27,fld:"",grid:0};n[28]={id:28,fld:"",grid:0};n[29]={id:29,fld:"REPAIRDAYSQUANTITYFILTERCONTAINER",grid:0};n[30]={id:30,fld:"",grid:0};n[31]={id:31,fld:"",grid:0};n[32]={id:32,fld:"LBLREPAIRDAYSQUANTITYFILTER",format:1,grid:0,evt:"e130q1_client",ctrltype:"textblock"};n[33]={id:33,fld:"",grid:0};n[34]={id:34,fld:"",grid:0};n[35]={id:35,fld:"",grid:0};n[36]={id:36,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCREPAIRDAYSQUANTITY",gxz:"ZV8cRepairDaysQuantity",gxold:"OV8cRepairDaysQuantity",gxvar:"AV8cRepairDaysQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV8cRepairDaysQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV8cRepairDaysQuantity=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCREPAIRDAYSQUANTITY",gx.O.AV8cRepairDaysQuantity,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV8cRepairDaysQuantity=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCREPAIRDAYSQUANTITY",",")},nac:gx.falseFn};n[37]={id:37,fld:"",grid:0};n[38]={id:38,fld:"",grid:0};n[39]={id:39,fld:"GAMEIDFILTERCONTAINER",grid:0};n[40]={id:40,fld:"",grid:0};n[41]={id:41,fld:"",grid:0};n[42]={id:42,fld:"LBLGAMEIDFILTER",format:1,grid:0,evt:"e140q1_client",ctrltype:"textblock"};n[43]={id:43,fld:"",grid:0};n[44]={id:44,fld:"",grid:0};n[45]={id:45,fld:"",grid:0};n[46]={id:46,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCGAMEID",gxz:"ZV9cGameId",gxold:"OV9cGameId",gxvar:"AV9cGameId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV9cGameId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV9cGameId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCGAMEID",gx.O.AV9cGameId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV9cGameId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCGAMEID",",")},nac:gx.falseFn};n[47]={id:47,fld:"",grid:0};n[48]={id:48,fld:"",grid:0};n[49]={id:49,fld:"REPAIRCOSTFILTERCONTAINER",grid:0};n[50]={id:50,fld:"",grid:0};n[51]={id:51,fld:"",grid:0};n[52]={id:52,fld:"LBLREPAIRCOSTFILTER",format:1,grid:0,evt:"e150q1_client",ctrltype:"textblock"};n[53]={id:53,fld:"",grid:0};n[54]={id:54,fld:"",grid:0};n[55]={id:55,fld:"",grid:0};n[56]={id:56,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCREPAIRCOST",gxz:"ZV10cRepairCost",gxold:"OV10cRepairCost",gxvar:"AV10cRepairCost",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV10cRepairCost=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV10cRepairCost=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCREPAIRCOST",gx.O.AV10cRepairCost,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV10cRepairCost=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCREPAIRCOST",",")},nac:gx.falseFn};n[57]={id:57,fld:"",grid:0};n[58]={id:58,fld:"",grid:0};n[59]={id:59,fld:"TECHNICIANIDFILTERCONTAINER",grid:0};n[60]={id:60,fld:"",grid:0};n[61]={id:61,fld:"",grid:0};n[62]={id:62,fld:"LBLTECHNICIANIDFILTER",format:1,grid:0,evt:"e160q1_client",ctrltype:"textblock"};n[63]={id:63,fld:"",grid:0};n[64]={id:64,fld:"",grid:0};n[65]={id:65,fld:"",grid:0};n[66]={id:66,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCTECHNICIANID",gxz:"ZV11cTechnicianId",gxold:"OV11cTechnicianId",gxvar:"AV11cTechnicianId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV11cTechnicianId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV11cTechnicianId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCTECHNICIANID",gx.O.AV11cTechnicianId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV11cTechnicianId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCTECHNICIANID",",")},nac:gx.falseFn};n[67]={id:67,fld:"",grid:0};n[68]={id:68,fld:"",grid:0};n[69]={id:69,fld:"REPAIRALTERNATETECHNICIANIDFILTERCONTAINER",grid:0};n[70]={id:70,fld:"",grid:0};n[71]={id:71,fld:"",grid:0};n[72]={id:72,fld:"LBLREPAIRALTERNATETECHNICIANIDFILTER",format:1,grid:0,evt:"e170q1_client",ctrltype:"textblock"};n[73]={id:73,fld:"",grid:0};n[74]={id:74,fld:"",grid:0};n[75]={id:75,fld:"",grid:0};n[76]={id:76,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:0,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[this.Grid1Container],fld:"vCREPAIRALTERNATETECHNICIANID",gxz:"ZV12cRepairAlternateTechnicianId",gxold:"OV12cRepairAlternateTechnicianId",gxvar:"AV12cRepairAlternateTechnicianId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.AV12cRepairAlternateTechnicianId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.ZV12cRepairAlternateTechnicianId=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("vCREPAIRALTERNATETECHNICIANID",gx.O.AV12cRepairAlternateTechnicianId,0)},c2v:function(){this.val()!==undefined&&(gx.O.AV12cRepairAlternateTechnicianId=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("vCREPAIRALTERNATETECHNICIANID",",")},nac:gx.falseFn};n[77]={id:77,fld:"",grid:0};n[78]={id:78,fld:"GRIDTABLE",grid:0};n[79]={id:79,fld:"",grid:0};n[80]={id:80,fld:"",grid:0};n[81]={id:81,fld:"BTNTOGGLE",grid:0,evt:"e180q1_client"};n[82]={id:82,fld:"",grid:0};n[83]={id:83,fld:"",grid:0};n[85]={id:85,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"vLINKSELECTION",gxz:"ZV5LinkSelection",gxold:"OV5LinkSelection",gxvar:"AV5LinkSelection",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.AV5LinkSelection=n)},v2z:function(n){n!==undefined&&(gx.O.ZV5LinkSelection=n)},v2c:function(n){gx.fn.setGridMultimediaValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84),gx.O.AV5LinkSelection,gx.O.AV17Linkselection_GXI)},c2v:function(n){gx.O.AV17Linkselection_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.AV5LinkSelection=this.val(n))},val:function(n){return gx.fn.getGridControlValue("vLINKSELECTION",n||gx.fn.currentGridRowImpl(84))},val_GXI:function(n){return gx.fn.getGridControlValue("vLINKSELECTION_GXI",n||gx.fn.currentGridRowImpl(84))},gxvar_GXI:"AV17Linkselection_GXI",nac:gx.falseFn};n[86]={id:86,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REPAIRID",gxz:"Z22RepairId",gxold:"O22RepairId",gxvar:"A22RepairId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A22RepairId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z22RepairId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("REPAIRID",n||gx.fn.currentGridRowImpl(84),gx.O.A22RepairId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A22RepairId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("REPAIRID",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[87]={id:87,lvl:2,type:"date",len:8,dec:0,sign:!1,ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REPAIRDATEFROM",gxz:"Z23RepairDateFrom",gxold:"O23RepairDateFrom",gxvar:"A23RepairDateFrom",dp:{f:0,st:!1,wn:!1,mf:!1,pic:"99/99/99",dec:0},ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A23RepairDateFrom=gx.fn.toDatetimeValue(n))},v2z:function(n){n!==undefined&&(gx.O.Z23RepairDateFrom=gx.fn.toDatetimeValue(n))},v2c:function(n){gx.fn.setGridControlValue("REPAIRDATEFROM",n||gx.fn.currentGridRowImpl(84),gx.O.A23RepairDateFrom,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A23RepairDateFrom=gx.fn.toDatetimeValue(this.val(n)))},val:function(n){return gx.fn.getGridDateTimeValue("REPAIRDATEFROM",n||gx.fn.currentGridRowImpl(84))},nac:gx.falseFn};n[88]={id:88,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REPAIRDAYSQUANTITY",gxz:"Z24RepairDaysQuantity",gxold:"O24RepairDaysQuantity",gxvar:"A24RepairDaysQuantity",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A24RepairDaysQuantity=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z24RepairDaysQuantity=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("REPAIRDAYSQUANTITY",n||gx.fn.currentGridRowImpl(84),gx.O.A24RepairDaysQuantity,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A24RepairDaysQuantity=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("REPAIRDAYSQUANTITY",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[89]={id:89,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"GAMEID",gxz:"Z16GameId",gxold:"O16GameId",gxvar:"A16GameId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A16GameId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z16GameId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("GAMEID",n||gx.fn.currentGridRowImpl(84),gx.O.A16GameId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A16GameId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("GAMEID",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[90]={id:90,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REPAIRCOST",gxz:"Z26RepairCost",gxold:"O26RepairCost",gxvar:"A26RepairCost",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A26RepairCost=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z26RepairCost=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("REPAIRCOST",n||gx.fn.currentGridRowImpl(84),gx.O.A26RepairCost,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A26RepairCost=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("REPAIRCOST",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[91]={id:91,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"TECHNICIANID",gxz:"Z27TechnicianId",gxold:"O27TechnicianId",gxvar:"A27TechnicianId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A27TechnicianId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z27TechnicianId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("TECHNICIANID",n||gx.fn.currentGridRowImpl(84),gx.O.A27TechnicianId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A27TechnicianId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("TECHNICIANID",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[92]={id:92,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:84,gxgrid:this.Grid1Container,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"REPAIRALTERNATETECHNICIANID",gxz:"Z29RepairAlternateTechnicianId",gxold:"O29RepairAlternateTechnicianId",gxvar:"A29RepairAlternateTechnicianId",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A29RepairAlternateTechnicianId=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z29RepairAlternateTechnicianId=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("REPAIRALTERNATETECHNICIANID",n||gx.fn.currentGridRowImpl(84),gx.O.A29RepairAlternateTechnicianId,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A29RepairAlternateTechnicianId=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("REPAIRALTERNATETECHNICIANID",n||gx.fn.currentGridRowImpl(84),",")},nac:gx.falseFn};n[93]={id:93,fld:"",grid:0};n[94]={id:94,fld:"",grid:0};n[95]={id:95,fld:"BTN_CANCEL",grid:0,evt:"e220q1_client"};this.AV6cRepairId=0;this.ZV6cRepairId=0;this.OV6cRepairId=0;this.AV7cRepairDateFrom=gx.date.nullDate();this.ZV7cRepairDateFrom=gx.date.nullDate();this.OV7cRepairDateFrom=gx.date.nullDate();this.AV8cRepairDaysQuantity=0;this.ZV8cRepairDaysQuantity=0;this.OV8cRepairDaysQuantity=0;this.AV9cGameId=0;this.ZV9cGameId=0;this.OV9cGameId=0;this.AV10cRepairCost=0;this.ZV10cRepairCost=0;this.OV10cRepairCost=0;this.AV11cTechnicianId=0;this.ZV11cTechnicianId=0;this.OV11cTechnicianId=0;this.AV12cRepairAlternateTechnicianId=0;this.ZV12cRepairAlternateTechnicianId=0;this.OV12cRepairAlternateTechnicianId=0;this.ZV5LinkSelection="";this.OV5LinkSelection="";this.Z22RepairId=0;this.O22RepairId=0;this.Z23RepairDateFrom=gx.date.nullDate();this.O23RepairDateFrom=gx.date.nullDate();this.Z24RepairDaysQuantity=0;this.O24RepairDaysQuantity=0;this.Z16GameId=0;this.O16GameId=0;this.Z26RepairCost=0;this.O26RepairCost=0;this.Z27TechnicianId=0;this.O27TechnicianId=0;this.Z29RepairAlternateTechnicianId=0;this.O29RepairAlternateTechnicianId=0;this.AV6cRepairId=0;this.AV7cRepairDateFrom=gx.date.nullDate();this.AV8cRepairDaysQuantity=0;this.AV9cGameId=0;this.AV10cRepairCost=0;this.AV11cTechnicianId=0;this.AV12cRepairAlternateTechnicianId=0;this.AV13pRepairId=0;this.AV5LinkSelection="";this.A22RepairId=0;this.A23RepairDateFrom=gx.date.nullDate();this.A24RepairDaysQuantity=0;this.A16GameId=0;this.A26RepairCost=0;this.A27TechnicianId=0;this.A29RepairAlternateTechnicianId=0;this.Events={e210q2_client:["ENTER",!0],e220q1_client:["CANCEL",!0],e180q1_client:["'TOGGLE'",!1],e110q1_client:["LBLREPAIRIDFILTER.CLICK",!1],e120q1_client:["LBLREPAIRDATEFROMFILTER.CLICK",!1],e130q1_client:["LBLREPAIRDAYSQUANTITYFILTER.CLICK",!1],e140q1_client:["LBLGAMEIDFILTER.CLICK",!1],e150q1_client:["LBLREPAIRCOSTFILTER.CLICK",!1],e160q1_client:["LBLTECHNICIANIDFILTER.CLICK",!1],e170q1_client:["LBLREPAIRALTERNATETECHNICIANIDFILTER.CLICK",!1]};this.EvtParms.REFRESH=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cRepairId",fld:"vCREPAIRID",pic:"ZZZ9"},{av:"AV7cRepairDateFrom",fld:"vCREPAIRDATEFROM",pic:""},{av:"AV8cRepairDaysQuantity",fld:"vCREPAIRDAYSQUANTITY",pic:"ZZZ9"},{av:"AV9cGameId",fld:"vCGAMEID",pic:"ZZZ9"},{av:"AV10cRepairCost",fld:"vCREPAIRCOST",pic:"ZZZ9"},{av:"AV11cTechnicianId",fld:"vCTECHNICIANID",pic:"ZZZ9"},{av:"AV12cRepairAlternateTechnicianId",fld:"vCREPAIRALTERNATETECHNICIANID",pic:"ZZZ9"}],[]];this.EvtParms.START=[[],[{ctrl:"FORM",prop:"Caption"}]];this.EvtParms["'TOGGLE'"]=[[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("ADVANCEDCONTAINER","Class")',ctrl:"ADVANCEDCONTAINER",prop:"Class"},{ctrl:"BTNTOGGLE",prop:"Class"}]];this.EvtParms["LBLREPAIRIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("REPAIRIDFILTERCONTAINER","Class")',ctrl:"REPAIRIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("REPAIRIDFILTERCONTAINER","Class")',ctrl:"REPAIRIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCREPAIRID","Visible")',ctrl:"vCREPAIRID",prop:"Visible"}]];this.EvtParms["LBLREPAIRDATEFROMFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("REPAIRDATEFROMFILTERCONTAINER","Class")',ctrl:"REPAIRDATEFROMFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("REPAIRDATEFROMFILTERCONTAINER","Class")',ctrl:"REPAIRDATEFROMFILTERCONTAINER",prop:"Class"}]];this.EvtParms["LBLREPAIRDAYSQUANTITYFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("REPAIRDAYSQUANTITYFILTERCONTAINER","Class")',ctrl:"REPAIRDAYSQUANTITYFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("REPAIRDAYSQUANTITYFILTERCONTAINER","Class")',ctrl:"REPAIRDAYSQUANTITYFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCREPAIRDAYSQUANTITY","Visible")',ctrl:"vCREPAIRDAYSQUANTITY",prop:"Visible"}]];this.EvtParms["LBLGAMEIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("GAMEIDFILTERCONTAINER","Class")',ctrl:"GAMEIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("GAMEIDFILTERCONTAINER","Class")',ctrl:"GAMEIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCGAMEID","Visible")',ctrl:"vCGAMEID",prop:"Visible"}]];this.EvtParms["LBLREPAIRCOSTFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("REPAIRCOSTFILTERCONTAINER","Class")',ctrl:"REPAIRCOSTFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("REPAIRCOSTFILTERCONTAINER","Class")',ctrl:"REPAIRCOSTFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCREPAIRCOST","Visible")',ctrl:"vCREPAIRCOST",prop:"Visible"}]];this.EvtParms["LBLTECHNICIANIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("TECHNICIANIDFILTERCONTAINER","Class")',ctrl:"TECHNICIANIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("TECHNICIANIDFILTERCONTAINER","Class")',ctrl:"TECHNICIANIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCTECHNICIANID","Visible")',ctrl:"vCTECHNICIANID",prop:"Visible"}]];this.EvtParms["LBLREPAIRALTERNATETECHNICIANIDFILTER.CLICK"]=[[{av:'gx.fn.getCtrlProperty("REPAIRALTERNATETECHNICIANIDFILTERCONTAINER","Class")',ctrl:"REPAIRALTERNATETECHNICIANIDFILTERCONTAINER",prop:"Class"}],[{av:'gx.fn.getCtrlProperty("REPAIRALTERNATETECHNICIANIDFILTERCONTAINER","Class")',ctrl:"REPAIRALTERNATETECHNICIANIDFILTERCONTAINER",prop:"Class"},{av:'gx.fn.getCtrlProperty("vCREPAIRALTERNATETECHNICIANID","Visible")',ctrl:"vCREPAIRALTERNATETECHNICIANID",prop:"Visible"}]];this.EvtParms.LOAD=[[],[{av:"AV5LinkSelection",fld:"vLINKSELECTION",pic:""}]];this.EvtParms.ENTER=[[{av:"A22RepairId",fld:"REPAIRID",pic:"ZZZ9",hsh:!0}],[{av:"AV13pRepairId",fld:"vPREPAIRID",pic:"ZZZ9"}]];this.EvtParms.GRID1_FIRSTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cRepairId",fld:"vCREPAIRID",pic:"ZZZ9"},{av:"AV7cRepairDateFrom",fld:"vCREPAIRDATEFROM",pic:""},{av:"AV8cRepairDaysQuantity",fld:"vCREPAIRDAYSQUANTITY",pic:"ZZZ9"},{av:"AV9cGameId",fld:"vCGAMEID",pic:"ZZZ9"},{av:"AV10cRepairCost",fld:"vCREPAIRCOST",pic:"ZZZ9"},{av:"AV11cTechnicianId",fld:"vCTECHNICIANID",pic:"ZZZ9"},{av:"AV12cRepairAlternateTechnicianId",fld:"vCREPAIRALTERNATETECHNICIANID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_PREVPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cRepairId",fld:"vCREPAIRID",pic:"ZZZ9"},{av:"AV7cRepairDateFrom",fld:"vCREPAIRDATEFROM",pic:""},{av:"AV8cRepairDaysQuantity",fld:"vCREPAIRDAYSQUANTITY",pic:"ZZZ9"},{av:"AV9cGameId",fld:"vCGAMEID",pic:"ZZZ9"},{av:"AV10cRepairCost",fld:"vCREPAIRCOST",pic:"ZZZ9"},{av:"AV11cTechnicianId",fld:"vCTECHNICIANID",pic:"ZZZ9"},{av:"AV12cRepairAlternateTechnicianId",fld:"vCREPAIRALTERNATETECHNICIANID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_NEXTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cRepairId",fld:"vCREPAIRID",pic:"ZZZ9"},{av:"AV7cRepairDateFrom",fld:"vCREPAIRDATEFROM",pic:""},{av:"AV8cRepairDaysQuantity",fld:"vCREPAIRDAYSQUANTITY",pic:"ZZZ9"},{av:"AV9cGameId",fld:"vCGAMEID",pic:"ZZZ9"},{av:"AV10cRepairCost",fld:"vCREPAIRCOST",pic:"ZZZ9"},{av:"AV11cTechnicianId",fld:"vCTECHNICIANID",pic:"ZZZ9"},{av:"AV12cRepairAlternateTechnicianId",fld:"vCREPAIRALTERNATETECHNICIANID",pic:"ZZZ9"}],[]];this.EvtParms.GRID1_LASTPAGE=[[{av:"GRID1_nFirstRecordOnPage"},{av:"GRID1_nEOF"},{ctrl:"GRID1",prop:"Rows"},{av:"AV6cRepairId",fld:"vCREPAIRID",pic:"ZZZ9"},{av:"AV7cRepairDateFrom",fld:"vCREPAIRDATEFROM",pic:""},{av:"AV8cRepairDaysQuantity",fld:"vCREPAIRDAYSQUANTITY",pic:"ZZZ9"},{av:"AV9cGameId",fld:"vCGAMEID",pic:"ZZZ9"},{av:"AV10cRepairCost",fld:"vCREPAIRCOST",pic:"ZZZ9"},{av:"AV11cTechnicianId",fld:"vCTECHNICIANID",pic:"ZZZ9"},{av:"AV12cRepairAlternateTechnicianId",fld:"vCREPAIRALTERNATETECHNICIANID",pic:"ZZZ9"}],[]];this.EvtParms.VALIDV_CREPAIRDATEFROM=[[],[]];this.setVCMap("AV13pRepairId","vPREPAIRID",0,"int",4,0);t.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid1"});t.addRefreshingVar(this.GXValidFnc[16]);t.addRefreshingVar(this.GXValidFnc[26]);t.addRefreshingVar(this.GXValidFnc[36]);t.addRefreshingVar(this.GXValidFnc[46]);t.addRefreshingVar(this.GXValidFnc[56]);t.addRefreshingVar(this.GXValidFnc[66]);t.addRefreshingVar(this.GXValidFnc[76]);t.addRefreshingParm(this.GXValidFnc[16]);t.addRefreshingParm(this.GXValidFnc[26]);t.addRefreshingParm(this.GXValidFnc[36]);t.addRefreshingParm(this.GXValidFnc[46]);t.addRefreshingParm(this.GXValidFnc[56]);t.addRefreshingParm(this.GXValidFnc[66]);t.addRefreshingParm(this.GXValidFnc[76]);this.Initialize()});gx.wi(function(){gx.createParentObj(this.gx0070)})