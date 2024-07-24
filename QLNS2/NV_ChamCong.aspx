<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NV_ChamCong.aspx.cs" Inherits="NV_ChamCong" MasterPageFile="NV.master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-xxl flex-grow-1 container-p-y">
        <div class="row my-4">
            <div class="col">
                <h3>Chấm công </h3>
                <div class="accordion" id="collapsibleSection">
                    <div class="card accordion-item pt-4">
                        <div id="collapseDeliveryAddress" class="accordion-collapse collapse show" aria-labelledby="headingDeliveryAddress" data-bs-parent="#collapsibleSection">
                            <div class="accordion-body">
                                <div class="row g-3">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <label class="col-sm-3 col-form-label text-sm-end" for="collapsible-fullname">Giờ vào</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtGioVao" runat="server" class="form-control phone-mask" TextMode="Time"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <label class="col-sm-3 col-form-label text-sm-end" for="collapsible-phone">Giờ ra</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtGioRa" runat="server" class="form-control phone-mask" TextMode="Time"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row g-3 pt-4">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <label class="col-sm-3 col-form-label text-sm-end" for="collapsible-fullname">Ngày</label>
                                            <div class="col-sm-9">
                                                <asp:TextBox ID="txtNgay" class="form-control phone-mask" runat="server" TextMode="Date"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                             <label class="col-sm-3 col-form-label text-sm-end" for="collapsible-fullname"></label>
                                            <div class="col-sm-9">
                                                <asp:Button ID="btnChamCong" Class="btn btn-warning" runat="server" Text="Chấm Công" OnClick="btnChamCong_Click"  />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /Chấm công -->
        <!-- /Nghỉ phép-->
         <div class="row my-4">
     <div class="col">
         <h3>Nghỉ phép </h3>
         <div class="accordion" id="collapsibleSection">
             <div class="card accordion-item pt-4">
                 <div id="collapseDeliveryAddress" class="accordion-collapse collapse show" aria-labelledby="headingDeliveryAddress" data-bs-parent="#collapsibleSection">
                     <div class="accordion-body">
                         <div class="row g-3 pt-4">
                             <div class="col-md-6">
                                 <div class="row">
                                     <label class="col-sm-3 col-form-label text-sm-end" for="collapsible-fullname">Ngày</label>
                                     <div class="col-sm-9">
                                         <asp:TextBox ID="Nghi" class="form-control phone-mask" runat="server" TextMode="Date"></asp:TextBox>
                                     </div>
                                 </div>
                             </div>
                             <div class="col-md-6">
                                 <div class="row">
                                      <label class="col-sm-3 col-form-label text-sm-end" for="collapsible-fullname"></label>
                                     <div class="col-sm-9">
                                        <asp:Button runat="server" ID="Button1" Text="Nghỉ phép"  Class="btn btn-warning" OnClientClick="return confirm('Bạn có chắc chắn muốn nghỉ phép không?');" OnClick="Button1_Click" />
                                         <asp:Label ID="lblMaNhanVien" runat="server" Text=""></asp:Label>

                                     </div>
                                 </div>
                             </div>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
     </div>
 </div>
    </div>

</asp:Content>
