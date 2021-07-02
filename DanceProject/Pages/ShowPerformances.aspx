<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowPerformances.aspx.cs" Inherits="DanceProject.Pages.ShowPerformances" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
body  {
background-color:#fae4e0;
}
        .style1
        {
            width: 100%;
            font-family: Tahoma;
            width:200px;
        }
        .style2
        {
            text-align: left;
            width: 256px;
            background-color:rgba(255,255,255,0.5);
        }
        .btn {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        width: 150px;
        height: 30px;
  border-radius: 4px;
}

.btn:hover {
  background-color: #555555;
  color: white;
}

.btn1 {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
  border-radius: 4px;
}

.btn1:hover {
  background-color: #555555;
  color: white;
}

#Panel1
{
    width:300px;
    height:50px;
    overflow:auto;
}

        #tbl
        {
            width:1340px;
        }
        
        #Panel2
        {
            overflow:auto;
            height:260px;
        }
        .style8
        {
            text-align: left;
            width: 256px;
            background-color: rgba(255,255,255,0.5);
            height: 80px;
        }
        .style9
        {
            text-align: left;
            width: 265px;
            background-color: rgba(255,255,255,0.5);
            height: 80px;
        }
        .style10
        {
            text-align: left;
            width: 256px;
            background-color: rgba(255,255,255,0.5);
            height: 31px;
        }
        .style11
        {
            text-align: left;
            width: 265px;
            background-color: rgba(255,255,255,0.5);
            height: 31px;
        }
        
#ImageButton8
{
    position:absolute;
    top:14px;
    left:1225px;
            height: 64px;
            width: 70px;
            right: -23px;
        }
        
        
        #Menu1
        {
            position:absolute;
            top:14px;
            left:0px;
        }
        
                #Menu2
        {
            position:absolute;
            top:14px;
            left:0px;
        }
                
        #Menu3
        {
            position:absolute;
            top:14px;
            left:0px;
        }
        
        
        #ImageButton7
        {
            position:absolute;
            top:24px;
            left:1102px;
            right: 160px;
        }
        
        #ImageButton9
        {
            position:absolute;
            top:24px;
            left:1156px;
            height: 42px;
            width: 43px;
        }
        .style12
        {
            text-align: left;
            width: 284px;
            background-color: rgba(255,255,255,0.5);
            height: 80px;
        }
        .style13
        {
            text-align: left;
            width: 284px;
            background-color: rgba(255,255,255,0.5);
            height: 31px;
        }
        #Button4
        {
            width:100px;
        }
        
                        #ImageButton14
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
            z-index:5;
        }
                
        #ImageButton15
        {
            position:absolute;
            top:27px;
            left:1102px;
            z-index:5;
            }
            
                    #Button8
        {
            background-color:#e6e6e6;
        }

                #Hi
        {
            position:absolute;
            top:70px;
            left:1093px;
            z-index:5;
            text-align: center;
            width: 170px;
        }
    </style>
    <script type="text/Javascript" language ="javascript" >  
function confirm_meth() {  
  return confirm("Are you sure you want to delete this performance?");
}  
</script> 
</head>
<body style="font-family: Tahoma; text-align: center;">
    <form id="form1" runat="server">
    
    <div>
    <asp:Label ID="Hi" runat="server" Text="hi"></asp:Label>
<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px">
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddDance.aspx" Text="Add a new dance" 
                        Value="Add a new dance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddPerformance.aspx" Text="Add a new performance" 
                        Value="Add a new performance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Admin" Value="Admin">
                    <asp:MenuItem NavigateUrl="BlockedUsers.aspx" 
                        Text="Show blocked users and new activities" 
                        Value="Show blocked users and new activities"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="Catagories.aspx" Text="Show categories" 
                        Value="Show categories"></asp:MenuItem>
                        </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

    <asp:ImageButton ID="ImageButton14" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton14_Click" 
        ToolTip="Log out" CausesValidation="False" />

        <asp:Menu ID="Menu2" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" >
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddDance.aspx" Text="Add a new dance" 
                        Value="Add a new dance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                    <asp:MenuItem NavigateUrl="AddPerformance.aspx" Text="Add a new performance" 
                        Value="Add a new performance"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

<asp:Menu ID="Menu3" runat="server" Orientation="Horizontal"
            StaticEnableDefaultPopOutImage="False" style="text-align: center"
            Height="70px"  Visible="false" BackColor="White" Width="1364px" 
            >
            <DynamicHoverStyle BackColor="#EEEEEE" />
            <DynamicMenuItemStyle BackColor="White" ForeColor="Black" />
            <DynamicSelectedStyle BackColor="#C5DDDC" />
            <Items>
                <asp:MenuItem Text="Dances" Value="Dances">
                    <asp:MenuItem NavigateUrl="ShowDances.aspx" Text="Show dances" 
                        Value="Show dances"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Performances" Value="Performances">
                    <asp:MenuItem NavigateUrl="ShowPerformances.aspx" Text="Show performances" 
                        Value="Show performances"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem Text="Users" Value="Users">
                    <asp:MenuItem NavigateUrl="ShowDancers.aspx" Text="Dancers" Value="Dancers">
                    </asp:MenuItem>
                    <asp:MenuItem NavigateUrl="ShowChoreographers.aspx" Text="Choreographers" 
                        Value="Choreographers"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="ContactUs.aspx" Text="Contact" Value="Contact us">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="AboutUs.aspx" Text="About us" Value="Contact us">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#DFDFDF" />
            <StaticMenuItemStyle BackColor="White" BorderColor="Black" ForeColor="Black" 
                HorizontalPadding="20px" VerticalPadding="25px"  />
            <StaticSelectedStyle BackColor="#C5DDDC" />
        </asp:Menu>

        <asp:ImageButton ID="ImageButton15" runat="server" 
            ImageUrl="/Photos/NotificationIcon.png" Height="35px" ToolTip="Notifications" 
            Width="35px" onclick="ImageButton15_Click" CausesValidation="False" />

        <br />

        <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="/Photos/Logo.png"
            onclick="ImageButton8_Click" ToolTip="Home page" CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton9" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
            onclick="ImageButton9_Click" CausesValidation="False" />
        <br />
    <table class="style2" id="tbl">
            <tr>
                <td class="style12">
        <asp:Label ID="Label5" runat="server" Text="Filter by dance styles: " 
                        style="font-weight: 700"></asp:Label>
                    <asp:Panel ID="Panel1" runat="server">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
                <td class="style8" width="1024">
                    <asp:Label ID="Label7" runat="server" Text="Filter by choreographers:" 
                        style="font-weight: 700"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="150px">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style9" width="1024">
                    <asp:Label ID="Label8" runat="server" Text="Filter by performance length:" 
                        style="font-weight: 700"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Text="" TextMode="Number" Placeholder="From"
                        Width="150px" ></asp:TextBox>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Text="" TextMode="Number" Placeholder="To"
                        Width="150px"></asp:TextBox>
                </td>
                <td class="style8" width="1024">
                    <asp:Label ID="Label26" runat="server" style="font-weight: 700" 
                        Text="Filter by performance place:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList4" runat="server" Width="150px">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style13">
                    <asp:Label ID="Label29" runat="server" style="font-weight: 700" 
                        Text="Past / future performances:"></asp:Label>
                    <asp:DropDownList ID="DropDownList5" runat="server" Height="16px" Width="150px">
                        <asp:ListItem>All</asp:ListItem>
                        <asp:ListItem>Past performances</asp:ListItem>
                        <asp:ListItem>Future performances</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style10" width="1024">
                    <asp:Label ID="Label15" runat="server" style="font-weight: 700" 
                        Text="Filter by dance:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList2" runat="server" Width="159px">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style11" width="1024">
                    <asp:Label ID="Label16" runat="server" style="font-weight: 700" 
                        Text="Filter by dancer:"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList3" runat="server" Width="150px">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
                <td class="style10" width="1024">
                    <asp:Label ID="Label28" runat="server" style="font-weight: 700" 
                        Text="Filter by creator choreographer:" Visible="False"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownList6" runat="server" Visible="False" 
                        Width="150px">
                        <asp:ListItem>All</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Label ID="Label17" runat="server" style="font-weight: 700" 
                        Text="Filter by performance date:"></asp:Label>
                    <br />
                    <asp:Label ID="Label18" runat="server" Text="From:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox4" runat="server" TextMode="Date" Width="150px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Photos/x.png" 
                        onclick="ImageButton1_Click" Height="10px" Width="10px"/>
                    <br />
                    <asp:Label ID="Label19" runat="server" Text="To:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox5" runat="server" TextMode="Date" Width="150px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/Photos/x.png" 
                        onclick="ImageButton2_Click" Height="10px" Width="10px"/>
                </td>
                <td class="style8" width="1024">
                    <asp:Label ID="Label20" runat="server" style="font-weight: 700" 
                        Text="Filter by creation date:"></asp:Label>
                    <br />
                    <asp:Label ID="Label21" runat="server" Text="From: "></asp:Label>
                    <asp:TextBox ID="TextBox6" runat="server" TextMode="Date" Width="150px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="/Photos/x.png" 
                        onclick="ImageButton3_Click" Height="10px" Width="10px"/>
                    <br />
                    <asp:Label ID="Label22" runat="server" Text="To:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox7" runat="server" TextMode="Date" Width="150px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="/Photos/x.png" 
                        onclick="ImageButton4_Click" Height="10px" Width="10px"/>
                </td>
                <td class="style9" width="1024">
                    <asp:Label ID="Label23" runat="server" style="font-weight: 700" 
                        Text="Filter by performance hours:"></asp:Label>
                    <br />
                    <asp:Label ID="Label24" runat="server" Text="From:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox8" runat="server" TextMode="Time" Width="150px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="/Photos/x.png" 
                        onclick="ImageButton5_Click" Height="10px" Width="10px"/>
                    <br />
                    <asp:Label ID="Label25" runat="server" Text="To:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox9" runat="server" TextMode="Time" Width="150px"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="/Photos/x.png" 
                        onclick="ImageButton6_Click" Height="10px" Width="10px"/>
                </td>
                <td class="style8" width="1024">
        <asp:Label ID="Label11" runat="server" Text="Search for performance name: " 
                        style="font-weight: 700"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Text="" Width="150px"></asp:TextBox>
                    &nbsp;<asp:ImageButton ID="ImageButton10" runat="server" 
                        onclick="ImageButton10_Click" ImageUrl="/Photos/SearchIcon.png" Height="30px" 
                        Width="30px"/>
                    </td>
            </tr>
            </table>
        <br />
    <asp:Button ID="Button3" runat="server" Text="Filter" onclick="Button3_Click" class="btn"/>
    &nbsp;<asp:Button ID="Button7" runat="server" Text="Show all performances" 
            onclick="Button7_Click" class="btn"/>
        &nbsp;<asp:Button ID="Button8" runat="server" onclick="Button8_Click" 
            Text="My performances" class="btn"/>
        <br />
        <asp:Panel ID="Panel2" runat="server">
            <asp:DataList ID="DataList1" runat="server" BorderColor="Black" 
            BorderWidth="0px" CellPadding="6" onitemcommand="DataList1_ItemCommand" 
            RepeatColumns="6" RepeatDirection="Horizontal" 
            onitemdatabound="DataList1_ItemDataBound" Width="500px">
                <ItemStyle Width="400px" Height="240px" />
                <ItemTemplate>
                    <table class="style1" frame="box" 
                    style="border-color: #000000; background-color: rgba(255, 255, 255, 0.5);" 
                    width="300px" cellpadding="6">
                        <tr>
                            <td style="text-align: center">
                                <asp:Image ID="Image1" runat="server" Height="142px" 
                                    ImageUrl='<%# Bind("PerformancePhoto") %>' Width="174px" />
                                <br />
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("PerformanceName") %>'></asp:Label>
                                <br />
                                <asp:ImageButton ID="ImageButton11" runat="server" 
                                    CommandArgument="Bind(&quot;PerformanceId&quot;)" CommandName="ShowPerformance" 
                                    Height="20px" ImageUrl="/Photos/ShowIcon.png" Width="20px" />
                                &nbsp;<asp:ImageButton ID="ImageButton12" runat="server" 
                                    CommandName="EditPerformance" Height="20px" ImageUrl="/Photos/PencilIcon.png" 
                                    Visible="False" Width="20px" />
                                &nbsp;<asp:ImageButton ID="ImageButton13" runat="server" 
                                    CommandName="DeletePerformance" Height="20px" ImageUrl="/Photos/DeleteIcon.png" 
                                    onclick="ImageButton13_Click" Visible="False" Width="20px" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("PerformanceId") %>' 
                                    Visible="False"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </asp:Panel>
        <br />
    </div>
    </form>
</body>
</html>
