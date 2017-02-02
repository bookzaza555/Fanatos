<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TempleProject.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            //Initialize Select2 Elements
            $(".select2").select2();
            //Datemask dd/mm/yyyy
            $("#datemask").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
            //Datemask2 mm/dd/yyyy
            $("#datemask2").inputmask("mm/dd/yyyy", { "placeholder": "mm/dd/yyyy" });
            //Money Euro
            $("[data-mask]").inputmask();
            //Date range picker
            $('#reservation').daterangepicker();
            //Date range picker with time picker
            $('#reservationtime').daterangepicker({ timePicker: true, timePickerIncrement: 30, format: 'MM/DD/YYYY h:mm A' });
            //Date range as a button
            $('#daterange-btn').daterangepicker(
                {
                    ranges: {
                        'Today': [moment(), moment()],
                        'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                        'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                        'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                        'This Month': [moment().startOf('month'), moment().endOf('month')],
                        'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                    },
                    startDate: moment().subtract(29, 'days'),
                    endDate: moment()
                },
            function (start, end) {
                $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            }
            );
            //iCheck for checkbox and radio inputs
            $('input[type="checkbox"].minimal, input[type="radio"].minimal').iCheck({
                checkboxClass: 'icheckbox_minimal-blue',
                radioClass: 'iradio_minimal-blue'
            });
            //Red color scheme for iCheck
            $('input[type="checkbox"].minimal-red, input[type="radio"].minimal-red').iCheck({
                checkboxClass: 'icheckbox_minimal-red',
                radioClass: 'iradio_minimal-red'
            });
            //Flat red color scheme for iCheck
            $('input[type="checkbox"].flat-red, input[type="radio"].flat-red').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                radioClass: 'iradio_flat-green'
            });
            //Colorpicker
            $(".my-colorpicker1").colorpicker();
            //color picker with addon
            $(".my-colorpicker2").colorpicker();
            //Timepicker
            $(".timepicker").timepicker({
                showInputs: false
            });
        });
    </script>

    <script type="text/javascript">
        $(function () {
            var thaiYear = function (ct) {
                var leap = 3;
                var dayWeek = ["พฤ.", "ศ.", "ส.", "อา.", "จ.", "อ.", "พ."];
                if (ct) {
                    var yearL = new Date(ct).getFullYear() - 543;
                    leap = (((yearL % 4 == 0) && (yearL % 100 != 0)) || (yearL % 400 == 0)) ? 2 : 3;
                    if (leap == 2) {
                        dayWeek = ["ศ.", "ส.", "อา.", "จ.", "อ.", "พ.", "พฤ."];
                    }
                }
                this.setOptions({
                    i18n: { th: { dayOfWeek: dayWeek } }, dayOfWeekStart: leap,
                })
            };
            $('#ContentPlaceHolder1_tbBirthdate,#ContentPlaceHolder1_tbDateInwork,#ContentPlaceHolder1_tbDateStartThisU,#ContentPlaceHolder1_tbMovementDate').datetimepicker({
                timepicker: false,
                format: 'd/m/Y',
                lang: 'th',
                onChangeMonth: thaiYear,
                onShow: thaiYear,
                yearOffset: 543,
                closeOnDateSelect: true,
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="default_page_style">
        <div class="ps-header">
            <img src="Image/Small/add.png" />สมัครสมาชิก
        </div>
        <div id="notification" runat="server"></div>

        <div class="panel panel-default">
            <div class="panel-body">
                        <div class="panel panel-default">
                            <table class="table table-striped table-bordered table-hover" style="width: 100%;">
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
                                    <td class="col1">Email<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control input-sm" Width="150px" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="col1">วันเกิด<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbBirthdate" runat="server" CssClass="form-control input-sm" Width="150px" required="required" tabindex="1"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="col1">ที่อยู่<span class="ps-lb-red" />*</td>
                                    <td class="col2">
                                        <asp:TextBox ID="tbAddress" runat="server" CssClass="form-control input-sm" Width="500px" Height="150px" TextMode="MultiLine" required="required" tabindex="1"></asp:TextBox>
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
        <asp:Button ID="btnOK" runat="server" CssClass="btn btn-success" Text="บันทึก" OnClick="btnOK_Click"></asp:Button>
        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="ยกเลิก"></asp:Button>
    </div>
    
</asp:Content>