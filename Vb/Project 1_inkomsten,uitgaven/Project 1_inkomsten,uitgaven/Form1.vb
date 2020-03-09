Public Class Form1
    ' ["Datum", "Bedrag", "Uitgave?", "Code"]
    'Public Geschiedenis(,) As String = {{"14/02/2020", "€10", "True", "1"}, {"17/02/2019", "€15", "False", "1"}, {"17/02/2019", "€15", "True", "101"}, {"17/02/2019", "€15", "False", "101"})
    Public Geschiedenis As New List(Of String)({"14/02/2020.€10.True.1", "17/02/2019.€15.False.1", "17/02/2019.€15.True.101", "17/02/2019.€15.False.101"})
    Public CodesInkomst As New List(Of String)({"001.Zakgeld", "101.Gevonden", "201.Studentenjob"})
    Public CodesUitgave As New List(Of String)({"001.Kledij", "101.Voedsel", "201.Uitgaan"})
    Public Rekeningstand As Decimal
    Public Admin As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'de grote van het venster aanpassen voor alle zichtbare dingen enzo
        Inladen()
        combobox(False)
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
            Dim codetext As String = cbbCodes.Text
            Dim Bedrag As Decimal = numBedrag.Text
            Dim AwBedrag As Decimal
            Dim Uitgave As Boolean
            Dim datum As Date = dtpTijd.Value

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

            'De code uit de messagebox halen
            Dim Code As String = cbbCodes.Text.Replace(")", "")
            Dim Codearray() As String
            Codearray = Code.Split("(")
            Code = Codearray(1)


            'invoegen in de tabel
            dtgDataveld.Rows.Add(datum.ToString("dd/MM/yyyy"), "€" & AwBedrag, Uitgave, Code)


        Catch

            MessageBox.Show("Gelieve een correct bedrag in te voeren.")

        End Try

        'als de tabel niet weergeven wordt dan wordt het onmiddelijk opgeslaan
        If Admin = False Then

            Opslaan()

        End If



    End Sub

    Private Sub combobox(Uitgave As Boolean)
        'de combobox herladen
        cbbCodes.Items.Clear()
        If Uitgave = True Then
            For Each item In CodesUitgave
                Dim codes() As String = {"Errorcode", "Error"}

                codes = item.Split(".")

                cbbCodes.Items.Add(codes(1) & "(" & codes(0) & ")")
            Next
        Else
            For Each item In CodesInkomst
                Dim codes() As String = {"Errorcode", "Error"}

                codes = item.Split(".")

                cbbCodes.Items.Add(codes(1) & "(" & codes(0) & ")")
            Next
        End If




    End Sub


    Private Sub Inladen()
        'De gegevens van de array op de dgv zetten
        dtgDataveld.Rows.Clear()
        Try
            Dim Code As String
            Dim Codetext As String = "error"
            Dim geschiedenisArray(Geschiedenis.Count, 3) As String
            Dim xindex As Integer
            For Each item In Geschiedenis
                Dim splitter() As String
                splitter = item.Split(".")
                geschiedenisArray(xindex, 0) = splitter(0)
                geschiedenisArray(xindex, 1) = splitter(1)
                geschiedenisArray(xindex, 2) = splitter(2)
                geschiedenisArray(xindex, 3) = splitter(3)
                xindex += 1

            Next

            For x = 0 To Geschiedenis.Count
                Code = geschiedenisArray(x, 3)
                'de code aanvullen totdat het 3 cijfers bevat
                'If geschiedenisArray(x, 3).Length = 1 Then
                '    Code = "00" & geschiedenisArray(x, 3)
                'ElseIf geschiedenisArray(x, 3).Length = 2 Then
                '    Code = "0" & geschiedenisArray(x, 3)
                'Else
                '    Code = geschiedenisArray(x, 3)
                'End If

                If geschiedenisArray(x, 2) = "True" Then
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
                        Codetext = "Code " & geschiedenisArray(x, 3) & " niet gevonden in uitgaven."
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
                        Codetext = "Code " & geschiedenisArray(x, 3) & " niet gevonden in inkomsten."
                    End If
                End If
                'een nieuwe rij maken met de data
                dtgDataveld.Rows.Add(geschiedenisArray(x, 0), geschiedenisArray(x, 1), geschiedenisArray(x, 2), Codetext)

                'variablen resetten
                Code = 0
                Codetext = "error"
            Next
        Catch ex As Exception
            'MessageBox.Show("Error bij inladen.")
            'MessageBox.Show(ex.ToString)
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
        Dim Geschiedenis2 As New List(Of String)
        For x = 0 To dtgDataveld.Rows.Count - 1
            'Een nieuwe array maken en de gegevens van de datagridvieuw erop opslaan
            Geschiedenis2.Add(dtgDataveld.Item(0, x).Value & "." & dtgDataveld.Item(1, x).Value & "." & dtgDataveld.Item(2, x).Value & "." & dtgDataveld.Item(3, x).Value)
            'Geschiedenis2(x, 0) = dtgDataveld.Item(0, x).Value
            'Geschiedenis2(x, 1) = dtgDataveld.Item(1, x).Value
            'Geschiedenis2(x, 2) = dtgDataveld.Item(2, x).Value
            'Geschiedenis2(x, 3) = dtgDataveld.Item(3, x).Value

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

        CodesInkomst.Sort()
        CodesUitgave.Sort()

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
        Code = txtCodeID.Text

        If Code.Contains("(") Or Naam.Contains("(") Or Code.Contains(".") Or Code.Contains(".") Then
            MessageBox.Show("Er zijn verboden tekens gevonden. In de code kunnen er geen . of ( of ) staan.")

        Else
            Try
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

                            codelijst = item.Split(".")
                            codetext = codelijst(0)

                        End If
                    Next
                Else

                    For Each item In CodesInkomst
                        If item.Contains(Code) Then

                            codelijst = item.Split(".")
                            codetext = codelijst(0)

                        End If
                    Next
                End If

                If codetext = "error" Then
                    Bestaand = False
                Else
                    Bestaand = True
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
                    MessageBox.Show("Code " & codetext & " is al eens gebruikt.")
                End If
            Catch
                MessageBox.Show("Er in een fout opgetreden bij het maken van de nieuwe code.")
            End Try
        End If
    End Sub

    Private Sub numBedrag_TextChanged(sender As Object, e As EventArgs) Handles numBedrag.TextChanged
        'Detecteren als het bedrag negatief of positief word
        If IsNumeric(numBedrag.Text) Then
            Dim uitgave As Boolean
            If numBedrag.Text < 0 Then
                uitgave = True
            Else
                uitgave = False
            End If
            combobox(uitgave)
        End If
    End Sub
End Class
