gx.evt.autoSkip=!1;gx.define("deleteallrepairs",!1,function(){this.ServerClass="deleteallrepairs";this.PackageName="GeneXus.Programs";this.ServerFullClass="deleteallrepairs.aspx";this.setObjectType("web");this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.SetStandaloneVars=function(){this.A22RepairId=gx.fn.getIntegerValue("REPAIRID",",")};this.e110v2_client=function(){return this.executeServerEvent("'DELETE REPAIRS'",!1,null,!1,!1)};this.e130v2_client=function(){return this.executeServerEvent("ENTER",!0,null,!1,!1)};this.e140v2_client=function(){return this.executeServerEvent("CANCEL",!0,null,!1,!1)};this.GXValidFnc=[];var n=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6];this.GXLastCtrlId=6;n[2]={id:2,fld:"",grid:0};n[3]={id:3,fld:"MAINTABLE",grid:0};n[4]={id:4,fld:"",grid:0};n[5]={id:5,fld:"",grid:0};n[6]={id:6,fld:"DELETEREPAIRS",grid:0,evt:"e110v2_client"};this.A22RepairId=0;this.Events={e110v2_client:["'DELETE REPAIRS'",!0],e130v2_client:["ENTER",!0],e140v2_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[],[]];this.EvtParms["'DELETE REPAIRS'"]=[[{av:"A22RepairId",fld:"REPAIRID",pic:"ZZZ9"}],[]];this.EvtParms.ENTER=[[],[]];this.setVCMap("A22RepairId","REPAIRID",0,"int",4,0);this.Initialize()});gx.wi(function(){gx.createParentObj(this.deleteallrepairs)})