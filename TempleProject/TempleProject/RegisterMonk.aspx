<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterMonk.aspx.cs" Inherits="TempleProject.RegisterMonk" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
 <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/add.png" />เพิ่มพระในวัด
        </div>
        <div id="notification" runat="server"></div>

        <div class="panel panel-default">
            <div class="panel-body">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
                                <tr>
                                    <td class="col1">ระดับพระ<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:DropDownList ID="ddlRank_Monk" runat="server" AutoPostBack="true" CssClass="form-control input-sm" Width="150px" required="required" tabindex="1"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1" style="width: 180px;">ชื่อผู้ใช้งาน<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbUsername" runat="server" CssClass="form-control input-sm" Width="150px" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">รหัสผู้ใช้งาน<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPassword" runat="server" CssClass="form-control input-sm" Width="150px" TextMode="Password" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ยืนยันรหัสผู้ใช้งาน<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPassword2" runat="server" CssClass="form-control input-sm" Width="150px" TextMode="Password" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">ชื่อ<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbName" runat="server" CssClass="form-control input-sm" Width="150px" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">นามสกุล<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbLastname" runat="server" CssClass="form-control input-sm" Width="150px" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="col1">เบอร์โทรศัพท์</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbPhone" runat="server" CssClass="form-control input-sm" Width="150px" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    
            </div>
        </div>
    </div>
    <div style="text-align: center;">
        <asp:Button ID="btnOK" runat="server" CssClass="btn btn-success" Text="บันทึก" OnClick="btnOK_Click" ></asp:Button>
        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="ยกเลิก"></asp:Button>
    </div>
    


</asp:Content>