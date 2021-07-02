<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPerformance.aspx.cs" Inherits="DanceProject.Pages.EditPerformance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
             body  {
background-color:#fae4e0;
}
        .btn {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
  border-radius: 4px;
  width:100px;
            text-align: center;
        }

.btn:hover {
  background-color: #555555;
  color: white;
}
.Panels
        {
            background-color:rgba(255,255,255,0.5);
            width: 990px;
            height:450px;
            position:absolute;
            top:150px;
            left:300px;
            border-radius:4px;
            border-width:2px;
            border-color:#555555;
            border-style:solid;
            overflow:auto;
        }
.grids
{
    background-color:rgba(255,255,255,0.5);
    position:absolute;
    left:145px;
    width:700px;
}
         #ImageButton1
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
        
        
        #ImageButton2
        {
            position:absolute;
            top:27px;
            left:1102px;
            right: 229px;
            z-index:5;
        }
        
        #ImageButton3
        {
            position:absolute;
            top:24px;
            left:1156px;
            height: 42px;
            width: 43px;
        }
        .style1
        {
            text-align: center;
        }
        
        #Calendar1
{
    position:absolute;
    left:295px;
        }
    

#Button7
{
    left:450px;
            right: 518px;
        }


 .btn2 {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
        width:130px;
  border-radius: 4px;
  position:absolute;
  top:95px;
            left: 297px;
        }

        .btn2:hover {
  background-color: #555555;
  color: white;
}

#FileUpload1 {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
        width:240px;
  border-radius: 4px;
        }

#FileUpload1:hover {
  background-color: #555555;
  color: white;
}

        
#Button8
{
    left:450px;
            right: 518px;
        }
        
            
        #Button11
{
    background-color:#e6e6e6;

}

#ImageButton4
{
    position:absolute;
    top:550px;
    left:60px;
}
#ImageButton5
{
    position:absolute;
    top:550px;
    left:120px;
}

    #ImageButton8
{
    position:absolute;
    top:550px;
    left:120px;
}

    #ImageButton8
{
    position:absolute;
    top:550px;
    left:120px;
}
                #ImageButton8
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
        }
        
                #Image1
{
    position:absolute;
    top:260px;
            left: 10px;
        }

#TextBox2
{
    position:absolute;
    top:410px;
    width:240px;
            left: 14px;
            text-align: left;
        }
        
        #FileUpload1
        {
           position:absolute;
    top:237px;
            left: 10px;
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
</head>
<body style="text-align: center; font-family: Tahoma">
    <form id="form1" runat="server">
    <div style="text-align: left">
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

        <asp:ImageButton ID="ImageButton2" runat="server" 
            ImageUrl="/Photos/NotificationIcon.png" Height="35px" ToolTip="Notifications" 
            Width="35px" onclick="ImageButton2_Click" CausesValidation="False" />

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
            Height="70px"  Visible="false" BackColor="White" Width="1364px">
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

        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Photos/Logo.png"
            onclick="ImageButton1_Click" ToolTip="Home page" CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
            onclick="ImageButton3_Click" CausesValidation="False" />
        <br />
        <br />
        <br />
        <br />
            
        <asp:Button ID="Button8" runat="server" Text="Dates" class="btn2" 
            onclick="Button8_Click1" Visible="False" />
        <asp:Button ID="Button11" runat="server" Text="Dances" 
            class="btn2" onclick="Button11_Click" Visible="False"/>
        <br />
        <asp:Image ID="Image1" runat="server" Height="149px" Width="240px" />
    <asp:ImageButton ID="ImageButton8" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton8_Click" 
        ToolTip="Log out" CausesValidation="False" />
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" Width="240px"/>
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Font-Size="XX-Large" Width="240px"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="TextBox2" ErrorMessage="This is a required field"></asp:RequiredFieldValidator>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Performance Id: " 
            style="font-weight: 700"></asp:Label>
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
        <br />
        <asp:ImageButton ID="ImageButton4" runat="server" onclick="ImageButton4_Click" 
            ImageUrl="/Photos/TickIcon.png" Height="50px" Width="50px"/>
        <br />
        <br />
        <asp:Panel ID="Panel1" runat="server" class="Panels">
            <div class="style1">
                <asp:Label ID="Label8" runat="server" Font-Size="X-Large" 
                    style="font-weight: 700" Text="Dances in this performance:"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton6" runat="server" onclick="ImageButton6_Click" 
                    ImageUrl="/Photos/PencilIcon.png" Height="50px" Width="50px"/>
                <br />
                <br />
            </div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" class="grids"
                style="text-align: center" onrowcommand="GridView1_RowCommand" 
                BorderStyle="None" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="DanceName" HeaderText="Dance name" />
                    <asp:ImageField DataImageUrlField="DancePhoto" HeaderText="Dance photo">
                        <ControlStyle Height="50px" Width="50px" />
                        <FooterStyle Height="50px" Width="50px" />
                        <HeaderStyle Height="50px" Width="50px" />
                        <ItemStyle Height="50px" Width="50px" />
                    </asp:ImageField>
                    <asp:ButtonField ButtonType="Button" CommandName="Show" HeaderText="Show"
                        ShowHeader="True" Text="Show" />
                </Columns>
                <HeaderStyle Height="50px" />
            </asp:GridView>
        </asp:Panel>
        <br />
        <asp:Panel ID="Panel2" runat="server" class="Panels" Visible="false">
            <div class="style1">
                <asp:Label ID="Label6" runat="server" Font-Size="X-Large" 
                    style="font-weight: 700; text-align: center;" Text="Performances dates:"></asp:Label>
                <br />
                <br />
                <asp:ImageButton ID="ImageButton7" runat="server" onclick="ImageButton7_Click" 
                    ImageUrl="/Photos/PencilIcon.png" Height="50px" Width="50px"/>
                <br />
                <br />
            </div>
            <asp:Calendar ID="Calendar1" runat="server" ondayrender="Calendar1_DayRender" 
                onselectionchanged="Calendar1_SelectionChanged" 
                Height="200px" Width="400px">
            </asp:Calendar>
            <div class="style1">
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="style1">
                <asp:GridView ID="GridView6" runat="server" AutoGenerateColumns="False" 
                    class="grids" onrowdatabound="GridView6_RowDataBound" 
                    onrowdeleting="GridView6_RowDeleting" Width="700px" BorderStyle="None" 
                    GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="PerformanceDate" HeaderText="Performance Date" 
                            SortExpression="PerformanceDate" />
                        <asp:BoundField DataField="PerformanceHour" HeaderText="Performance Hour" 
                            SortExpression="PerformanceHour" />
                        <asp:BoundField DataField="PerformancePlace" HeaderText="Performance Place" 
                            SortExpression="PerformancePlace" />
                        <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Delete" 
                            ShowHeader="True" Text="Delete" />
                    </Columns>
                    <HeaderStyle Height="50px" />
                    <RowStyle Height="40px" />
                </asp:GridView>
                <br />
            </div>
        </asp:Panel>
        <br />
        <br />
        <br />
&nbsp;<asp:ImageButton ID="ImageButton5" runat="server" 
            onclick="ImageButton5_Click" ImageUrl="/Photos/X.png" Height="50px" 
            Width="50px" />
    
        <br />
        <br />
        <asp:Label ID="Label5" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
