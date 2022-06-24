Imports System.Data.SqlClient

Public Class Form1

    'Connect DB
    Dim connection As SqlConnection = New SqlConnection("Data Source=DESKTOP-PIHCL6D\MYSQLSERVER2;Initial Catalog=Cal;Integrated Security=True")

    'Class
    Public Class user
        Public UserID As String
        Public Weight As Decimal
        Public Height As Decimal
        Public Age As Integer
        Public Tdde As Decimal


        'Method 1
        Public Function Getbmi(ByVal Height, ByVal Weight)
            Dim bmi As Decimal = (Weight / (Height * Height)) * 10000
            Return bmi
        End Function

        'Method 2
        Public Function GetBmr(ByVal Height, ByVal Age, ByVal Weight)
            Dim bmr As Decimal = (88.362 + (13.397 * Weight) + (4.799 * Height) - (5.677 * Age))
            Return bmr
        End Function

    End Class

    Public Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        ' insert
        Dim human As CalDataSet.CalRow = Me.CalDataSet.Cal.NewRow()
        human.UserID = TextEdit1.Text
        human.Height = TextEdit3.Text
        human.Weight = TextEdit2.Text
        human.Age = TextEdit4.Text
        human.bmi = (human.Weight / (human.Height * human.Height)) * 10000
        human.bmr = (88.362 + (13.397 * human.Weight) + (4.799 * human.Height) - (5.677 * human.Age))
        Dim Tdde As Decimal

        If ComboBox1.SelectedItem = "Sedentary" Then
            Tdde = ((88.362 + (13.397 * human.Weight) + (4.799 * human.Height) - (5.677 * human.Age)) * 1.2)
        ElseIf ComboBox1.SelectedItem = "Lightly Active" Then
            Tdde = ((88.362 + (13.397 * human.Weight) + (4.799 * human.Height) - (5.677 * human.Age)) * 1.375)
        ElseIf ComboBox1.SelectedItem = "Moderately Active" Then
            Tdde = ((88.362 + (13.397 * human.Weight) + (4.799 * human.Height) - (5.677 * human.Age)) * 1.55)
        Else
            Tdde = ((88.362 + (13.397 * human.Weight) + (4.799 * human.Height) - (5.677 * human.Age)) * 1.75)
        End If
        human.Tdde = Tdde
        Me.CalDataSet.Cal.Rows.Add(human)
        Me.CalTableAdapter.Update(Me.CalDataSet)
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'CalDataSet.Cal' table. You can move, or remove it, as needed.
        Me.CalTableAdapter.Fill(Me.CalDataSet.Cal)
        ComboBox1.Items.Add("Sedentary")
        ComboBox1.Items.Add("Lightly Active")
        ComboBox1.Items.Add("Moderately Active")
        ComboBox1.Items.Add("Very Active")

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Save
        Me.CalTableAdapter.Update(Me.CalDataSet)
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        'Delete
        Dim i As Integer = DataGridView1.CurrentRow.Index
        Me.CalDataSet.Cal.Rows(i).Delete()
        Me.CalTableAdapter.Update(Me.CalDataSet)
    End Sub

    Private Sub TextEdit4_EditValueChanged(sender As System.Object, e As System.EventArgs) Handles TextEdit4.EditValueChanged

    End Sub
End Class
