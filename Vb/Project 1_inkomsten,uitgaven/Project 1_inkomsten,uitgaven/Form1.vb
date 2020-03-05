Public Class Form1
    ' ["Datum", "Bedrag", "Uitgave?", "Code"]
    Public Geschiedenis(,) As String = {{"14/02/2020", "€10", "True", "1"}, {"17/02/2019", "€15", "False", "1"}, {"17/02/2019", "€15", "True", "101"}, {"17/02/2019", "€15", "False", "101"}}
    Public CodesInkomst As New List(Of String)({"001.Zakgeld", "101.Gevonden", "201.Studentenjob"})
    Public CodesUitgave As New List(Of String)({"001.Kledij", "101.Voedsel", "201.Uitgaan"})
    Public Rekeningstand As Decimal
    Public Admin As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'de grote van het venster aanpassen voor alle zichtbare dingen enzo
        Inladen()
        Me.Width = 300
        Me.Height = 136
        dtgDataveld.Hide()
        lblLijn.Hide()
        btnRefresh.Hide()
        btnExport.Enabled = False
        btnImport.Enabled = False
        btnOpslaan.Enabled = False
        lblCodeID.Hide()
        lblNaam.Hide()
        lblNieweC.Hide()
        cbUitgave.Hide()
        txtCodeID.Hide()
        txtCodeNaam.Hide()
        btnCodeMaken.Hide()
        btnCodesWeergeven.Hide()

    End Sub

    Private Sub btnInvoegen_Click(sender As Object, e As EventArgs) Handles btnInvoegen.Click
        Try
            Dim code As Integer
            Dim Bedrag As Decimal = numBedrag.Text
            Dim AwBedrag As Decimal
            Dim Uitgave As Boolean
            Dim datum As Date = dtpTijd.Value

            Try
                code = txtCode.Text
            Catch ex As Exception
                MessageBox.Show("Gelieve een correcte code in te voeren.")
            End Try

            'kijken als het een in of uitgave is
            If Bedrag > 0 Then

                AwBedrag = Bedrag
                Uitgave = False

            ElseIf Bedrag < 0 Then

                AwBedrag -= Bedrag
                Uitgave = True

            Else

                MessageBox.Show("Gelieve een reëel getal anders dan 0 in te geven.")

            End If

            dtgDataveld.Rows.Add(datum.ToString("dd/MM/yyyy"), "€" & AwBedrag, Uitgave, code)


        Catch

            MessageBox.Show("Gelieve een correct bedrag in te voeren.")

        End Try

        If Admin = False Then

            Opslaan()

        End If



    End Sub

    Private Sub Inladen()
        'De gegevens van de array op de dgv zetten
        dtgDataveld.Rows.Clear()
        Try
            Dim Code As String
            Dim Codetext As String = "error"

            For x = 0 To Geschiedenis.GetUpperBound(0)
                'de code aanvullen totdat het 3 cijfers bevat
                If Geschiedenis(x, 3).Length = 1 Then
                    Code = "00" & Geschiedenis(x, 3)
                ElseIf Geschiedenis(x, 3).Length = 2 Then
                    Code = "0" & Geschiedenis(x, 3)
                Else
                    Code = Geschiedenis(x, 3)
                End If

                If Geschiedenis(x, 2) = "True" Then
                    'kijken in de correcte lijst met codes voor een item met de juiste code
                    'xxx.Naamcode
                    For Each item In CodesUitgave
                        If item.Contains(Code) Then
                            Dim Codelijst() As String

                            Codelijst = item.Split(".")
                            Codetext = Codelijst(1)

                        End If
                    Next
                    If Codetext = "error" Then
                        Codetext = "Code " & Geschiedenis(x, 3) & " niet gevonden in uitgaven."
                    End If
                Else

                    For Each item In CodesInkomst
                        If item.Contains(Code) Then
                            Dim Codelijst() As String

                            Codelijst = item.Split(".")
                            Codetext = Codelijst(1)

                        End If
                    Next
                    If Codetext = "error" Then
                        Codetext = "Code " & Geschiedenis(x, 3) & " niet gevonden in inkomsten."
                    End If
                End If
                'een nieuwe rij maken met de data
                dtgDataveld.Rows.Add(Geschiedenis(x, 0), Geschiedenis(x, 1), Geschiedenis(x, 2), Codetext)

                'variablen resetten
                Code = 0
                Codetext = "error"
            Next
        Catch ex As Exception
            MessageBox.Show("Error bij inladen.")
            MessageBox.Show(ex.ToString)
        End Try

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Inladen()
    End Sub

    Private Sub cbAdmin_CheckedChanged(sender As Object, e As EventArgs) Handles cbAdmin.CheckedChanged
        'Het wisselen tussen het gedetailleerde vieuw en gewoon
        If Admin = True Then
            Me.Width = 300
            Me.Height = 136
            dtgDataveld.Hide()
            lblLijn.Hide()
            btnRefresh.Hide()
            btnOpslaan.Enabled = False
            Admin = False
            lblCodeID.Hide()
            lblNaam.Hide()
            lblNieweC.Hide()
            cbUitgave.Hide()
            txtCodeID.Hide()
            txtCodeNaam.Hide()
            btnCodeMaken.Hide()
            btnCodesWeergeven.Hide()

        ElseIf Admin = False Then
            Me.Width = 490
            Me.Height = 340
            dtgDataveld.Show()
            lblLijn.Show()
            btnRefresh.Show()
            btnOpslaan.Enabled = True
            Admin = True
            lblCodeID.Show()
            lblNaam.Show()
            lblNieweC.Show()
            cbUitgave.Show()
            txtCodeID.Show()
            txtCodeNaam.Show()
            btnCodeMaken.Show()
            btnCodesWeergeven.Show()

        End If
    End Sub

    Private Sub BtnOpslaan_Click(sender As Object, e As EventArgs) Handles btnOpslaan.Click
        Opslaan()
    End Sub

    Private Sub Opslaan()
        Dim Geschiedenis2(dtgDataveld.Rows.Count - 1, 3) As String
        For x = 0 To dtgDataveld.Rows.Count - 1
            'Een nieuwe array maken en de gegevens van de datagridvieuw erop opslaan
            Geschiedenis2(x, 0) = dtgDataveld.Item(0, x).Value
            Geschiedenis2(x, 1) = dtgDataveld.Item(1, x).Value
            Geschiedenis2(x, 2) = dtgDataveld.Item(2, x).Value
            Geschiedenis2(x, 3) = dtgDataveld.Item(3, x).Value

        Next

        'For Each item In Geschiedenis2
        '    MessageBox.Show(item)
        'Next

        Geschiedenis = Geschiedenis2

        Inladen()
    End Sub

    Private Sub btnCodesWeergeven_Click(sender As Object, e As EventArgs) Handles btnCodesWeergeven.Click
        'Een messagebox geven per bestaande code
        Dim itemsplit() As String
        For Each item In CodesInkomst
            itemsplit = item.Split(".")
            MessageBox.Show("Inkomst " & itemsplit(1) & " met code " & itemsplit(0))
        Next

        For Each item In CodesUitgave
            itemsplit = item.Split(".")
            MessageBox.Show("Uitgave " & itemsplit(1) & " met code " & itemsplit(0))
        Next

    End Sub

    Private Sub btnCodeMaken_Click(sender As Object, e As EventArgs) Handles btnCodeMaken.Click
        Dim Naam As String
        Dim Code As String
        Naam = txtCodeNaam.Text
        Code = txtCode.Text

        'de code aanvullen totdat het 3 cijfers bevat
        If txtCodeID.Text.Length = 1 Then
            Code = "00" & txtCodeID.Text
        ElseIf txtCodeID.Text.Length = 2 Then
            Code = "0" & txtCodeID.Text
        ElseIf txtCodeID.Text.Length = 3 Then
            Code = txtCodeID.Text
        Else
            MessageBox.Show("Code is lang. Maximaal 3 tekens is voorgesteld.")
            Code = txtCodeID.Text
        End If

        ''
        Dim Bestaand As Boolean
        Dim codetext As String = "error"
        Dim codelijst() As String
        If cbUitgave.Checked = "True" Then
            'kijken in de correcte lijst met codes voor een item met de juiste code
            'xxx.Naamcode
            For Each item In CodesUitgave
                If item.Contains(Code) Then

                    Codelijst = item.Split(".")
                    codetext = Codelijst(1)

                End If
            Next
        Else

            For Each item In CodesInkomst
                If item.Contains(Code) Then

                    Codelijst = item.Split(".")
                    Codetext = Codelijst(1)

                End If
            Next
        End If

        If codetext = "error" Then
            Bestaand = False
        End If

        ''Als de code al gebruikt is dit niet doen
        If Bestaand = False Then
            'Een nieuw item maken in de gepaste lijst
            If cbUitgave.Checked = False Then
                CodesInkomst.Add(Code & "." & Naam)
            Else
                CodesUitgave.Add(Code & "." & Naam)
            End If
        Else
            MessageBox.Show("Code" & codetext & "is al eens gebruikt.")
        End If
    End Sub
End Class
