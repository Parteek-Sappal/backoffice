// ********************************
// Clsm.Clearall(roleid.Parent)
// Clsm.Clearall(roleid.Parent)

class _failedMemberConversionMarker1
{
}
#error Cannot convert ClassBlockSyntax - see comment for details
/* Cannot convert ClassBlockSyntax, CONVERSION ERROR: Object reference not set to an instance of an object. in 'Partial Class usermanagemen...' at character 2
   at ICSharpCode.CodeConverter.CSharp.HandledEventsAnalyzer.CreateEventContainer(EventContainerSyntax p, SemanticModel semanticModel)
   at ICSharpCode.CodeConverter.CSharp.HandledEventsAnalyzer.<>c__DisplayClass11_0.<HandledEvent>b__2(MethodStatementSyntax _, HandlesClauseItemSyntax e)
   at System.Linq.Enumerable.<SelectManyIterator>d__23`3.MoveNext()
   at System.Linq.Enumerable.<SelectManyIterator>d__17`2.MoveNext()
   at System.Linq.Enumerable.<SelectManyIterator>d__17`2.MoveNext()
   at System.Linq.Lookup`2.Create[TSource](IEnumerable`1 source, Func`2 keySelector, Func`2 elementSelector, IEqualityComparer`1 comparer)
   at ICSharpCode.CodeConverter.CSharp.HandledEventsAnalyzer.<AnalyzeAsync>d__7.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at ICSharpCode.CodeConverter.CSharp.DeclarationNodeVisitor.<GetMethodWithHandlesAsync>d__63.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at ICSharpCode.CodeConverter.CSharp.DeclarationNodeVisitor.<ConvertMembersAsync>d__40.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at ICSharpCode.CodeConverter.CSharp.DeclarationNodeVisitor.<VisitClassBlock>d__46.MoveNext()
--- End of stack trace from previous location where exception was thrown ---
   at System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw()
   at ICSharpCode.CodeConverter.CSharp.CommentConvertingVisitorWrapper.<ConvertHandledAsync>d__8`1.MoveNext()

Input:

Partial Class usermanagement_addrole
    Inherits Global.System.Web.UI.Page
    Dim Clsm As New mainclass
    Dim rid As Integer
    Dim qstring As String
    Dim consql As New SqlConnection
    Dim Parameters As New Global.System.Collections.Hashtable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As Global.System.EventArgs) Handles Me.Load
        trsuccess.Visible = False
        trerror.Visible = False
        trnotice.Visible = False
        If Me.Page.IsPostBack = False Then
            Try
                Me.Parameters.Clear()
                Me.Clsm.datalistDatashow_Parameter(DlAccess, "select * from ModuleMaster where status=1 order by displayorder", Me.Parameters)
                Me.showList()
                tr_per.Visible = False
                If Global.Microsoft.VisualBasic.Conversion.Val(Me.Request.QueryString("roleid")) <> 0 Then
                    DlAccess.Visible = True
                    Me.qstring = Global.Microsoft.VisualBasic.Strings.Replace(Me.Request.QueryString("roleid"), "'", "''")
                    Me.Parameters.Clear()
                    Me.Parameters.Add("@roleid", Global.Microsoft.VisualBasic.Conversion.Val(Me.qstring))
                    Me.Clsm.MoveRecord_Parameter(Me, roleid.Parent, "Select * from RoleMaster where roleid =@roleid", Me.Parameters)
                    Dim dscheck As DataSet
                    Dim i, j As Integer
                    Me.Parameters.Clear()
                    Me.Parameters.Add("@roleid", Global.Microsoft.VisualBasic.Conversion.Val(Me.qstring))
                    dscheck = Me.Clsm.senddataset_Parameter("select * from Role_details where roleid=@roleid", Me.Parameters)

                    Dim item As DataListItem

                    For Each item In DlAccess.Items
                        Dim txtmid As TextBox = CType(item.FindControl("txtmid"), TextBox)
                        Dim GridView2 As GridView = CType(item.FindControl("GridView2"), GridView)
                        For i = 0 To GridView2.Rows.Count - 1
                            Dim chkbx2 As CheckBox = GridView2.Rows(i).FindControl("chkselect")

                            For j = 0 To dscheck.Tables(0).Rows.Count - 1
                                If GridView2.Rows(i).Cells(0).Text = dscheck.Tables(0).Rows(j).Item("formid") Then
                                    If dscheck.Tables(0).Rows(j).Item("viewform") = True Then
                                        chkbx2.Checked = True
                                    End If
                                End If
                            Next
                        Next
                    Next
                End If
            Catch ex As Global.System.Exception
                trerror.Visible = True
                lblerror.Text = ex.Message.ToString
            End Try
        End If
    End Sub

    Protected Sub checkedall()
        '********************************
        Dim i As Integer
        Dim item As DataListItem
        For Each item In DlAccess.Items
            Dim GridView2 As GridView = CType(item.FindControl("GridView2"), GridView)
            For i = 0 To GridView2.Rows.Count - 1
                Dim chkbx2 As CheckBox = GridView2.Rows(i).FindControl("chkselect")
                Dim selectall As CheckBox = GridView2.HeaderRow.FindControl("selectall")
                If selectall.Checked = True Then
                    chkbx2.Checked = True
                ElseIf selectall.Checked = False Then
                    chkbx2.Checked = False
                End If
            Next
        Next
    End Sub

    Protected Sub showList()
        DlAccess.Visible = True
        tr_per.Visible = True
        Dim i, r As Integer
        Dim item As DataListItem
        For Each item In DlAccess.Items
            Dim GridView2 As GridView = CType(item.FindControl("GridView2"), GridView)
            For i = 0 To GridView2.Rows.Count - 1
                Dim chkbx2 As CheckBox = GridView2.Rows(i).FindControl("chkselect")
                chkbx2.Checked = False
            Next
        Next
    End Sub
    Friend Sub datalistgrdeachitem(ByVal var As Integer)
        Try
            Dim item As DataListItem
            Dim i, ctr As Integer
            Me.Parameters.Clear()
            Me.Parameters.Add("@rid", Global.Microsoft.VisualBasic.Conversion.Val(Me.rid))
            Me.Clsm.ExecuteQry_Parameter("delete from Role_details where roleid=@rid", Me.Parameters)
            Me.consql.ConnectionString = Me.Clsm.strconnect
            Me.consql.Open()

            For Each item In DlAccess.Items
                Dim txtmid As TextBox = CType(item.FindControl("txtmid"), TextBox)
                Dim GridView2 As GridView = CType(item.FindControl("GridView2"), GridView)
                Dim lblMName As Label = CType(item.FindControl("lblMName"), Label)
                For i = 0 To GridView2.Rows.Count - 1
                    Dim chkbx2 As CheckBox = GridView2.Rows(i).FindControl("chkselect")
                    Dim fmid As String = GridView2.Rows(i).Cells(0).Text.ToString()

                    If chkbx2.Checked Then
                        Dim objcmd3 As SqlCommand = New SqlCommand("Role_detailsSP", Me.consql)
                        objcmd3.CommandType = CommandType.StoredProcedure
                        objcmd3.Parameters.AddWithValue("@roleid", Me.rid)
                        objcmd3.Parameters.AddWithValue("@formid", fmid)
                        objcmd3.Parameters.AddWithValue("@viewform", 1)
                        objcmd3.Parameters.AddWithValue("@mode", 1)
                        objcmd3.ExecuteNonQuery()

                    Else
                        Dim objcmd3 As SqlCommand = New SqlCommand("Role_detailsSP", Me.consql)
                        objcmd3.CommandType = CommandType.StoredProcedure
                        objcmd3.Parameters.AddWithValue("@roleid", Me.rid)
                        objcmd3.Parameters.AddWithValue("@formid", fmid)
                        objcmd3.Parameters.AddWithValue("@viewform", 0)
                        objcmd3.Parameters.AddWithValue("@mode", 1)
                        objcmd3.ExecuteNonQuery()
                    End If

                Next
            Next
        Catch ex As Global.System.Exception
            trerror.Visible = True
            lblerror.Text = ex.Message.ToString
        End Try
    End Sub

    Protected Sub DlAccess_ItemCommand(ByVal source As Object, ByVal e As Global.System.Web.UI.WebControls.DataListCommandEventArgs) Handles DlAccess.ItemCommand
        Dim btnhide As ImageButton = e.Item.FindControl("btnhide")
        Dim btnshow As ImageButton = e.Item.FindControl("btnshow")
        Dim GridView2 As GridView = e.Item.FindControl("GridView2")
        Dim gridSubDepartment As GridView = e.Item.FindControl("gridSubDepartment")

        Dim gridcampus As GridView = e.Item.FindControl("gridcampus")

        If e.CommandName = "show" Then
            btnhide.Visible = True
            btnshow.Visible = False
            GridView2.Visible = True
            gridSubDepartment.Visible = True
            gridcampus.Visible = True


        End If
        If e.CommandName = "hide" Then
            GridView2.Visible = False
            gridSubDepartment.Visible = False
            btnhide.Visible = False
            btnshow.Visible = True
            gridcampus.Visible = False
        End If
        
    End Sub
    Protected Sub DlAccess_ItemDataBound(ByVal sender As Object, ByVal e As Global.System.Web.UI.WebControls.DataListItemEventArgs) Handles DlAccess.ItemDataBound
        Dim GridView2 As GridView = e.Item.FindControl("GridView2")
        Dim gridSubDepartment As GridView = e.Item.FindControl("gridSubDepartment")
        Dim gridcampus As GridView = e.Item.FindControl("gridcampus")

        Dim btnhide As ImageButton = e.Item.FindControl("btnhide")
        Dim btnshow As ImageButton = e.Item.FindControl("btnshow")
        Dim txtmid As TextBox = e.Item.FindControl("txtmid")
        Me.Parameters.Clear()
        Me.Parameters.Add("@Moduleid", Val(txtmid.Text))
        Me.Clsm.GridviewData_Parameter(GridView2, "SELECT distinct fmas.FormCaption, fmas.Formid FROM  FormMaster fmas INNER JOIN ModuleMaster mmas ON fmas.Moduleid = mmas.Moduleid where mmas.status=1 and fmas.status=1 and mmas.Moduleid=@Moduleid", Me.Parameters)
        GridView2.Visible = False
        If txtmid.Text = 19 Then
            Me.Parameters.Clear()
            Me.Clsm.GridviewData_Parameter(gridSubDepartment, "select collageid,collagename from collage_master  where status=1  order by displayorder", Me.Parameters)
            gridSubDepartment.Visible = False
        End If
        If txtmid.Text = 41 Then
            Me.Parameters.Clear()
            Me.Clsm.GridviewData_Parameter(gridcampus, "select campusid,campus_name from campus  where status=1  order by displayorder", Me.Parameters)
            gridcampus.Visible = False
        End If
        


    End Sub



    Protected Sub GridView2_RowDataBound(ByVal sender As Object, ByVal e As Global.System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Or e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(0).Visible = False
        End If



    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As Global.System.EventArgs) Handles Me.PreInit
        If Me.Session("currenttheme") Is Nothing = False Then
            Me.Page.Theme = Me.Session("currenttheme")
        End If
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As Global.System.EventArgs) Handles btnSubmit.Click
        Try

            If Me.Page.IsValid Then
                If Me.Clsm.MasterSave(Me, roleid.Parent, 3, mainclass.Mode.modeCheckDuplicate, "RoleMasterSP", Me.Session("UserId")) > 0 Then
                    trnotice.Visible = True
                    lblnotice.Text = "This Role is already exist."
                    Exit Sub
                End If

                If Val(roleid.Text) = 0 Then
                    rolestatus.Checked = True
                    Me.rid = Me.Clsm.MasterSave(Me, roleid.Parent, 3, mainclass.Mode.modeAdd, "RoleMasterSP", Me.Session("UserId"))
                    Me.datalistgrdeachitem(Global.Microsoft.VisualBasic.Conversion.Val(Me.rid))
                    Me.SaveDepartmentDetails(Global.Microsoft.VisualBasic.Conversion.Val(Me.rid))
                    Me.SaveCampusDetails(Global.Microsoft.VisualBasic.Conversion.Val(Me.rid))
                    'Clsm.Clearall(roleid.Parent)
                    trsuccess.Visible = True
                    lblsuccess.Text = "Role added successfully."
                Else
                    Me.rid = Me.Clsm.MasterSave(Me, roleid.Parent, 3, mainclass.Mode.modeModify, "RoleMasterSP", Me.Session("UserId"))
                    Me.datalistgrdeachitem(Global.Microsoft.VisualBasic.Conversion.Val(Me.rid))
                    Me.SaveDepartmentDetails(Global.Microsoft.VisualBasic.Conversion.Val(Me.rid))
                    Me.SaveCampusDetails(Global.Microsoft.VisualBasic.Conversion.Val(Me.rid))
                    Me.Response.Redirect("viewrole.aspx?edit=edit")
                End If
            End If
        Catch er As Global.System.Exception
            trerror.Visible = True
            lblerror.Text = er.Message.ToString
        End Try
        rolestatus.Checked = True
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As Global.System.EventArgs) Handles btnCancel.Click
        If Val(roleid.Text) = 0 Then
            'Clsm.Clearall(roleid.Parent)
        Else
            Me.Response.Redirect("viewrole.aspx")
        End If
        rolestatus.Checked = True
    End Sub

    Protected Sub selectall_CheckedChanged(ByVal sender As Object, ByVal e As Global.System.EventArgs)
        Global.System.Threading.Thread.Sleep(1000)
        Me.checkedall()
    End Sub

    Protected Sub SaveDepartmentDetails(ByVal RId As Integer)

        roleid.Text = RId.ToString()
        Dim i As Integer = 0
        For Each dl As DataListItem In DlAccess.Items
            Dim txtmid As TextBox = DirectCast(dl.FindControl("txtmid"), TextBox)

            If txtmid.Text = 19 Then

                Me.Parameters.Clear()
                Me.Parameters.Add("@rid", Global.Microsoft.VisualBasic.Conversion.Val(RId))
                Me.Clsm.ExecuteQry_Parameter("delete from collage_Management where roleid=@rid", Me.Parameters)

                Dim gridSubDepartment As GridView = DirectCast(dl.FindControl("gridSubDepartment"), GridView)
                For k As Integer = 0 To gridSubDepartment.Rows.Count - 1
                    Dim lbldeptid As Label = gridSubDepartment.Rows(k).FindControl("lbldeptid")
                    Dim chkselect As CheckBox = gridSubDepartment.Rows(k).FindControl("chkselect")
                    If chkselect.Checked = True Then
                        Dim objcmd As SqlCommand = New SqlCommand("collage_managementSP", Me.consql)
                        objcmd.CommandType = CommandType.StoredProcedure
                        objcmd.Parameters.AddWithValue("@collageid", Val(lbldeptid.Text))
                        objcmd.Parameters.AddWithValue("@roleid", RId)
                        objcmd.Parameters.AddWithValue("@status", 1)
                        objcmd.Parameters.AddWithValue("@Uname", "admin")
                        objcmd.Parameters.AddWithValue("@mode", 1)
                        objcmd.ExecuteNonQuery()
                    End If

                Next

            End If
            i = i + 1
        Next

    End Sub

    Protected Sub SaveCampusDetails(ByVal RId As Integer)

        roleid.Text = RId.ToString()
        Dim i As Integer = 0
        For Each dl As DataListItem In DlAccess.Items
            Dim txtmid As TextBox = DirectCast(dl.FindControl("txtmid"), TextBox)

            If txtmid.Text = 41 Then

                Me.Parameters.Clear()
                Me.Parameters.Add("@rid", Global.Microsoft.VisualBasic.Conversion.Val(RId))
                Me.Clsm.ExecuteQry_Parameter("delete from campusrole_Management where roleid=@rid", Me.Parameters)

                Dim gridcampus As GridView = DirectCast(dl.FindControl("gridcampus"), GridView)
                For k As Integer = 0 To gridcampus.Rows.Count - 1
                    Dim lblcampusid As Label = gridcampus.Rows(k).FindControl("lblcampusid")
                    Dim chkselect As CheckBox = gridcampus.Rows(k).FindControl("chkselect")
                    If chkselect.Checked = True Then
                        Dim objcmd As SqlCommand = New SqlCommand("campusrole_ManagementSP", Me.consql)
                        objcmd.CommandType = CommandType.StoredProcedure
                        objcmd.Parameters.AddWithValue("@campusid", Val(lblcampusid.Text))
                        objcmd.Parameters.AddWithValue("@roleid", RId)
                        objcmd.Parameters.AddWithValue("@status", 1)
                        objcmd.Parameters.AddWithValue("@Uname", "sadmin")
                        objcmd.Parameters.AddWithValue("@mode", 1)
                        objcmd.ExecuteNonQuery()
                    End If

                Next

            End If
            i = i + 1
        Next

    End Sub

    Protected Sub gridSubDepartment_RowDataBound(ByVal sender As Object, ByVal e As Global.System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dsdepartment As DataSet
            Me.Parameters.Clear()
            Dim qstring = Me.Request.QueryString("roleid")
            Me.Parameters.Add("@roleid", Global.Microsoft.VisualBasic.Conversion.Val(qstring))
            dsdepartment = Me.Clsm.senddataset_Parameter("select * from collage_Management where roleid=@roleid", Me.Parameters)
            Dim lbldeptid As Label = e.Row.FindControl("lbldeptid")
            Dim chkselect As CheckBox = e.Row.FindControl("chkselect")
            For j As Integer = 0 To dsdepartment.Tables(0).Rows.Count - 1
                If lbldeptid.Text = dsdepartment.Tables(0).Rows(j).Item("collageid") Then
                    chkselect.Checked = True
                End If
            Next
        End If
    End Sub


    Protected Sub gridcampus_RowDataBound(ByVal sender As Object, ByVal e As Global.System.Web.UI.WebControls.GridViewRowEventArgs)
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim dsdepartment As DataSet
            Me.Parameters.Clear()
            Dim qstring = Me.Request.QueryString("roleid")
            Me.Parameters.Add("@roleid", Global.Microsoft.VisualBasic.Conversion.Val(qstring))
            dsdepartment = Me.Clsm.senddataset_Parameter("select * from campusrole_Management where roleid=@roleid", Me.Parameters)
            Dim lblcampusid As Label = e.Row.FindControl("lblcampusid")
            Dim chkselect As CheckBox = e.Row.FindControl("chkselect")
            For j As Integer = 0 To dsdepartment.Tables(0).Rows.Count - 1
                If lblcampusid.Text = dsdepartment.Tables(0).Rows(j).Item("campusid") Then
                    chkselect.Checked = True
                End If
            Next
        End If
    End Sub

End Class

 */