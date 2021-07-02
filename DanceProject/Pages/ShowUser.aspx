<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowUser.aspx.cs" Inherits="DanceProject.Pages.ShowUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
body {
background-color:#fae4e0;
}

#ImageButton1
{
    position:absolute;
    top:14px;
    left:1225px;
            height: 64px;
            width: 70px;
            right: 2px;
            z-index:5;
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
    #Button6
{
    left:300px;
    background-color:#e6e6e6;

}

#Button6
{
    left:300px;
    background-color:#e6e6e6;

}

#Button7
{
    left:512px;
            right: 393px;
        }
#Button8
{
    left:727px;

}
#Button9
{
    left:945px;

}

         .btn {
  background-color: white;
  color: black;
  border: 1px solid #555555;
        height: 30px;
        width:200px;
  border-radius: 4px;
  position:absolute;
  top:97px;
            left: 10px;
            right: 56px;
        }
        .btn:hover {
  background-color: #555555;
  color: white;
}  

        .style1
        {
            text-align: center;
        }

        #Image1
{
    position:absolute;
    top:260px;
            left: 10px;
        }

#Label4
{
    position:absolute;
    top:410px;
    width:240px;
            left: 14px;
            text-align: left;
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
        
        #GridView1
        {
            position:absolute;
            left:120px;
        }
        
        #GridView2
        {
            position:absolute;
            left:120px;
        }
        
        #GridView3
        {
            position:absolute;
            left:120px;
        }
        
        #ImageButton4
        {
            position:absolute;
            top:550px;
            left:119px;
            z-index:5;
        }
                #ImageButton5
        {
            position:absolute;
            top:550px;
            left:120px;
            z-index:5;
        }


        
                        #ImageButton6
        {
            position:absolute;
            top:24px;
            left:1035px;
            height: 42px;
            width: 43px;
            z-index:5;
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
<body style="font-family: Tahoma">
    <form id="form1" runat="server">
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

        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/Photos/Logo.png"
            onclick="ImageButton1_Click" ToolTip="Home page" CausesValidation="False"/>
        <br />
        <br />
        <br />
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="/Photos/ProfileIcon.png" ToolTip="Your profile" 
            onclick="ImageButton3_Click" CausesValidation="False" />
    <div class="style1">
        <br />
        <br />
        <br />
        <asp:Button ID="Button8" runat="server" Text="Performances" class="btn" onclick="Button8_Click" 
            />
        <br />
        <br />
        <asp:Image ID="Image1" runat="server" Height="157px" Width="274px" />
    <asp:ImageButton ID="ImageButton6" runat="server" 
        ImageUrl="/Photos/LogoutIcon.png" onclick="ImageButton6_Click" 
        ToolTip="Log out" CausesValidation="False" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Font-Size="XX-Large" Width="274px" 
            ></asp:Label>
        <br />
        <br />
        <asp:Panel ID="Panel2" runat="server" class="Panels" Visible="true">
                <asp:Label ID="Label20" runat="server" Font-Size="X-Large" 
                    style="font-weight: 700" Text="General information:"></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label1" runat="server" style="font-weight: 700" Text="User Id:"></asp:Label>
                &nbsp;<asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                &nbsp;<br /> 
                <br />
                <strong>User Category: </strong>
                <asp:Label ID="Label13" runat="server"></asp:Label>
                <strong>
                <br />
                <br />
                </strong>
                <asp:Label ID="Label5" runat="server" style="font-weight: 700" 
                    Text="User Birth Date:"></asp:Label>
                &nbsp;<asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label7" runat="server" style="font-weight: 700" 
                    Text="User Phone Number:"></asp:Label>
                &nbsp;<asp:Label ID="Label8" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Label ID="Label9" runat="server" style="font-weight: 700" 
                    Text="User Email:"></asp:Label>
                &nbsp;<asp:Label ID="Label10" runat="server"></asp:Label>
                <br />
                <br />
                <strong>Is Admin: </strong>
                <asp:Label ID="Label16" runat="server"></asp:Label>
                <strong>
                <br />
                <br />
                Is Blocked:</strong>&nbsp;
                <asp:Label ID="Label17" runat="server"></asp:Label>
        </asp:Panel>
        <br />
        <br />
        <asp:Button ID="Button6" runat="server" Text="General information" class="btn" 
            onclick="Button6_Click"/>
        <asp:Button ID="Button7" runat="server" Text="Dances" class="btn" 
            onclick="Button7_Click"/>
        <asp:Button ID="Button9" runat="server" Text="Choreographer's performances" class="btn" 
            onclick="Button9_Click" Visible="False"/>
        <asp:Panel ID="Panel3" runat="server" class="Panels" Visible="false">
            <asp:Label ID="Label11" runat="server" 
        style="text-align: left; font-weight: 700" 
    Font-Size="X-Large">This user&#39;s dances:</asp:Label>
            <br />
            <asp:Label ID="Label15" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                onrowcommand="GridView1_RowCommand" style="text-align: center" 
                Width="700px" BorderStyle="None" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="DanceName" HeaderText="Dance Name" 
                        SortExpression="DanceName" />
                    <asp:ImageField DataImageUrlField="DancePhoto" HeaderText="Dance Photo">
                        <ControlStyle Height="50px" Width="50px" />
                        <ItemStyle Height="50px" Width="50px" />
                    </asp:ImageField>
                    <asp:ButtonField ButtonType="Button" CommandName="ShowDance" HeaderText="Show" 
                        ShowHeader="True" Text="Show" />
                </Columns>
                <HeaderStyle Height="50px" />
            </asp:GridView>
        </asp:Panel>
        <br />
        <br />
        <asp:ImageButton ID="ImageButton4" runat="server" onclick="ImageButton4_Click" ImageUrl="/Photos/PencilIcon.png"
            Visible="False" Height="50px" Width="50px" />
        &nbsp;<asp:ImageButton ID="ImageButton5" runat="server" 
            onclick="ImageButton5_Click" Visible="False" ImageUrl="/Photos/BlockIcon.png" 
            Height="50px" Width="50px"/>
        
        <asp:Panel ID="Panel4" runat="server" Visible="false" class="Panels">
            <asp:Label ID="Label12" runat="server" style="font-weight: 700" 
        Text="The performances this user has dances in:" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:Label ID="Label14" runat="server"></asp:Label>
            <br />
            <br />
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                onrowcommand="GridView2_RowCommand" style="text-align: center" 
                Width="700px" BorderStyle="None" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="PerformanceName" HeaderText="Performance Name" 
                        SortExpression="DanceName" />
                    <asp:ImageField DataImageUrlField="PerformancePhoto" 
                        HeaderText="Performance Photo">
                        <ControlStyle Height="50px" Width="50px" />
                        <ItemStyle Height="50px" Width="50px" />
                    </asp:ImageField>
                    <asp:ButtonField ButtonType="Button" CommandName="ShowPerformance" 
                        HeaderText="Show" ShowHeader="True" Text="Show" />
                </Columns>
                <HeaderStyle Height="50px" />
            </asp:GridView>
        </asp:Panel>
        
        <asp:Panel ID="Panel5" runat="server" Visible="false" class="Panels">
            <asp:Label ID="Label18" runat="server" style="font-weight: 700" 
        Text="This choreographer's performances:" Visible="False" Font-Size="X-Large"></asp:Label>
            <br />
            <asp:Label ID="Label19" runat="server"></asp:Label>
            <br />
            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
                onrowcommand="GridView2_RowCommand" style="text-align: center" 
                Width="700px" BorderStyle="None" GridLines="Horizontal">
                <Columns>
                    <asp:BoundField DataField="PerformanceName" HeaderText="Performance Name" 
                        SortExpression="DanceName" />
                    <asp:ImageField DataImageUrlField="PerformancePhoto" 
                        HeaderText="Performance Photo">
                        <ControlStyle Height="50px" Width="50px" />
                        <ItemStyle Height="50px" Width="50px" />
                    </asp:ImageField>
                    <asp:ButtonField ButtonType="Button" CommandName="ShowPerformance" 
                        HeaderText="Show" ShowHeader="True" Text="Show" />
                </Columns>
                <HeaderStyle Height="50px" />
            </asp:GridView>
            <br />
        </asp:Panel>
        <br />
    <br />
&nbsp;<br />
    </form>
</body>
</html>
