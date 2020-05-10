Public Class Form1
    Public Personen As New List(Of String)({"1234567980;Thymen;60", "0000000001;Alex;15"}) 'als nummer;naam;bedrag
    Public Broden As New List(Of String)({"Leeg", "Limburgs Terf", "Melkwit", "Volkoren F.Fijn Volkoren", "Volkoren F.Grof Volkoren", "Boeren Tarwe", "Wit", "Tarwe", "BBD M.Boeren Donker Meergranen", "Gogh Meergranen", "Spelt(Half)", "Boeren Tijger Tarwe", "Boeren Tijger Wit", "Boeren Mout"})
    'Als afkorting.vol / vol
    Public Locatie As New List(Of String)({"15;2;1.50", "", "", "", "", "", "", "", "", "", "", "", "", "", "13;5;2.00"}) 'opgeslagen als aantal;typeindex;prijs(in euro)
    Public Munten() As Integer = ({4, 5, 6, 7, 3})

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'combobox invullen met broodkeuzes
        BroodRefresh()
        MuntenTellen()

    End Sub

    Private Sub Muntentellen()
        num2.Value = Munten(0)
        num1.Value = Munten(1)
        num50.Value = Munten(2)
        num10.Value = Munten(3)
        num5.Value = Munten(4)
    End Sub

    Private Sub BroodRefresh()
        'alles opnieuw inladen
        For Each item In Broden
            cbType.Items.Add((item.Replace(".", "/")))
        Next

        'Gegevens in knoppen inladen
        btnBrood1.Text = Broden(Naamsplit(Locatie(0), 1)).Split(".")(0)
        btnBrood2.Text = Broden(Naamsplit(Locatie(1), 1)).Split(".")(0)
        btnBrood3.Text = Broden(Naamsplit(Locatie(2), 1)).Split(".")(0)
        btnBrood4.Text = Broden(Naamsplit(Locatie(3), 1)).Split(".")(0)
        btnBrood5.Text = Broden(Naamsplit(Locatie(4), 1)).Split(".")(0)
        btnBrood6.Text = Broden(Naamsplit(Locatie(5), 1)).Split(".")(0)
        btnBrood7.Text = Broden(Naamsplit(Locatie(6), 1)).Split(".")(0)
        btnBrood8.Text = Broden(Naamsplit(Locatie(7), 1)).Split(".")(0)
        btnBrood9.Text = Broden(Naamsplit(Locatie(8), 1)).Split(".")(0)
        btnBrood10.Text = Broden(Naamsplit(Locatie(9), 1)).Split(".")(0)
        btnBrood11.Text = Broden(Naamsplit(Locatie(10), 1)).Split(".")(0)
        btnBrood12.Text = Broden(Naamsplit(Locatie(11), 1)).Split(".")(0)
        btnBrood13.Text = Broden(Naamsplit(Locatie(12), 1)).Split(".")(0)
        btnBrood14.Text = Broden(Naamsplit(Locatie(13), 1)).Split(".")(0)
        btnBrood15.Text = Broden(Naamsplit(Locatie(14), 1)).Split(".")(0)

        'prijzen in labels inladen
        lblNummer1.Text = "1-€" & (Naamsplit(Locatie(0), 2))
        lblNummer2.Text = "2-€" & (Naamsplit(Locatie(1), 2))
        lblNummer3.Text = "3-€" & (Naamsplit(Locatie(2), 2))
        lblNummer4.Text = "4-€" & (Naamsplit(Locatie(3), 2))
        lblNummer5.Text = "5-€" & (Naamsplit(Locatie(4), 2))
        lblNummer6.Text = "6-€" & (Naamsplit(Locatie(5), 2))
        lblNummer7.Text = "7-€" & (Naamsplit(Locatie(6), 2))
        lblNummer8.Text = "8-€" & (Naamsplit(Locatie(7), 2))
        lblNummer9.Text = "9-€" & (Naamsplit(Locatie(8), 2))
        lblNummer10.Text = "10-€" & (Naamsplit(Locatie(9), 2))
        lblNummer11.Text = "11-€" & (Naamsplit(Locatie(10), 2))
        lblNummer12.Text = "12-€" & (Naamsplit(Locatie(11), 2))
        lblNummer13.Text = "13-€" & (Naamsplit(Locatie(12), 2))
        lblNummer14.Text = "14-€" & (Naamsplit(Locatie(13), 2))
        lblNummer15.Text = "15-€" & (Naamsplit(Locatie(14), 2))
    End Sub

    Private Sub NumLocatie_ValueChanged(sender As Object, e As EventArgs) Handles numLocatie.ValueChanged
        Try
            cbType.SelectedIndex = Naamsplit(Locatie(numLocatie.Value - 1), 1)
            numPrijs.Value = Naamsplit(Locatie(numLocatie.Value - 1), 2).replace(".", "")
            numAantal.Value = Naamsplit(Locatie(numLocatie.Value - 1), 0)
        Catch
            cbType.SelectedIndex = 0
        End Try
    End Sub

    Public Function Naamsplit(Text As String, Effect As Integer)
        Try
            'De gegeven tekst opsplitsen in delen en alleen het tweede item doorgeven
            Dim Resultaat(2) As String
            Resultaat = Text.Split(";")


            Return Resultaat(Effect)
        Catch
            'Het vak is leeg
            Return (0)
        End Try
    End Function

    Public Function CentEuro(Bedrag)
        'De waarde omvormen van cent naar euro(een punt voor de voorlaatste 2 cijfers zetten)
        Dim prijs(1) As String
        Dim waarde As String = ""
        If Bedrag < 100 Then
            If Bedrag.Length = 1 Then
                waarde = "0.0" & Bedrag
            ElseIf Bedrag.Length = 2 Then
                waarde = "0." & Bedrag
            End If
        Else
            waarde = Bedrag
            prijs(0) = waarde.Substring(0, waarde.Length - 2)
            prijs(1) = waarde.Substring(waarde.Length - 2, 2)
            waarde = prijs(0) & "." & prijs(1)
        End If
        Return waarde
    End Function
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        'De broodaanpassingen opslaan
        Try
            If (Not (numLocatie.Value < 1)) And numLocatie.Value - 1 < 16 And numAantal.Value > 0 Then
                'eerst de getallen omvormen naar het correcte formaat en dan opslaan als 1 string
                Locatie(numLocatie.Value - 1) = numAantal.Value & ";" & cbType.SelectedIndex & ";" & CentEuro(numPrijs.Value)
                numLocatie.Value = 0
                numAantal.Value = 0
                numPrijs.Value = 0
                cbType.SelectedIndex = 0
                MessageBox.Show("Succesvol opgeslagen.")
                Refresh()
            Else
                MessageBox.Show("Ongeldige waarden zijn ingegeven.")
            End If
        Catch
            MessageBox.Show("Deze locatie is niet beschikbaar of de ingegeven waarden zijn ongeldig.")
        End Try
        BroodRefresh()
    End Sub


    'Hulpknoppen
    Private Sub BtnLocatieHulp_Click(sender As Object, e As EventArgs) Handles btnLocatieHulp.Click
        MessageBox.Show("Je kunt een vakje aanklikken of het nummer ingeven.")
    End Sub

    Private Sub btnHulpBrood_Click(sender As Object, e As EventArgs) Handles btnHulpBrood.Click
        MessageBox.Show("Je kiest eerst de locatie van een brood, dan kun je de gegevens van die locatie weergeven en aanpassen met de invoervelden.")
    End Sub

    Private Sub BtnHelpPersoon_Click(sender As Object, e As EventArgs) Handles btnHelpPersoon.Click
        MessageBox.Show("Je kunt hier een vast bedrag op iemands rekening zetten of een simpele berekening ingeven zoals +10 of -12.")
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles BtnClear.Click
        Locatie.Clear()
        Dim x As Integer
        Do Until X = 15
            x = x + 1
            Locatie.Add("")
        Loop
        BroodRefresh
    End Sub

    Private Sub txtKlantcode_TextChanged() Handles txtKlantcode.TextChanged
        'als er een geldige code in het veld staat de gegevens ervan weergeven
        If txtKlantcode.Text.Length = 10 Then
            Try
                Dim split(2) As String
                For Each item In Personen
                    split = item.Split(";")
                    If split(0) = txtKlantcode.Text Then
                        lblNaam.Text = split(1)
                        lblBedrag.Text = "€" & split(2)
                    End If
                Next
            Catch ex As Exception

            End Try
        Else
            lblNaam.Text = "Geen persoon gevonden"
            lblBedrag.Text = "€0"
        End If
    End Sub

    'de knoppen van de machine zelf
    Private Sub BtnBrood1_Click(sender As Object, e As EventArgs) Handles btnBrood1.Click
        numLocatie.Value = 1
    End Sub
    Private Sub BtnBrood2_Click(sender As Object, e As EventArgs) Handles btnBrood2.Click
        numLocatie.Value = 2
    End Sub
    Private Sub BtnBrood3_Click(sender As Object, e As EventArgs) Handles btnBrood3.Click
        numLocatie.Value = 3
    End Sub
    Private Sub BtnBrood4_Click(sender As Object, e As EventArgs) Handles btnBrood4.Click
        numLocatie.Value = 4
    End Sub
    Private Sub BtnBrood5_Click(sender As Object, e As EventArgs) Handles btnBrood5.Click
        numLocatie.Value = 5
    End Sub
    Private Sub BtnBrood6_Click(sender As Object, e As EventArgs) Handles btnBrood6.Click
        numLocatie.Value = 6
    End Sub
    Private Sub BtnBrood7_Click(sender As Object, e As EventArgs) Handles btnBrood7.Click
        numLocatie.Value = 7
    End Sub
    Private Sub BtnBrood8_Click(sender As Object, e As EventArgs) Handles btnBrood8.Click
        numLocatie.Value = 8
    End Sub
    Private Sub BtnBrood10_Click(sender As Object, e As EventArgs) Handles btnBrood10.Click
        numLocatie.Value = 10
    End Sub
    Private Sub BtnBrood11_Click(sender As Object, e As EventArgs) Handles btnBrood11.Click
        numLocatie.Value = 11
    End Sub
    Private Sub BtnBrood12_Click(sender As Object, e As EventArgs) Handles btnBrood12.Click
        numLocatie.Value = 12
    End Sub
    Private Sub BtnBrood13_Click(sender As Object, e As EventArgs) Handles btnBrood13.Click
        numLocatie.Value = 13
    End Sub
    Private Sub BtnBrood14_Click(sender As Object, e As EventArgs) Handles btnBrood14.Click
        numLocatie.Value = 14
    End Sub
    Private Sub BtnBrood15_Click(sender As Object, e As EventArgs) Handles btnBrood15.Click
        numLocatie.Value = 15
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        BroodRefresh()
    End Sub

    Private Sub BtnOpslaanPersoon_Click(sender As Object, e As EventArgs) Handles btnOpslaanPersoon.Click
        'Kijkt in de lijst met personen voor een overeenkomstige code
        Try
            Dim PersoonBedrag As Decimal
            Dim Persoonnaam As String = "Niet gevonden"
            Dim split(2) As String
            Dim index As Integer = -1
            For Each item In Personen
                index = index + 1
                split = item.Split(";")
                If split(0) = txtKlantcode.Text Then
                    'Persoon gevonden
                    Persoonnaam = split(1)
                    PersoonBedrag = split(2)
                    'zoeken achter bewerking
                    If txtBedrag.Text.Contains("-") Then
                        PersoonBedrag = PersoonBedrag - txtBedrag.Text.Replace("-", "")
                    ElseIf txtBedrag.Text.Contains("+") Then
                        PersoonBedrag = PersoonBedrag + txtBedrag.Text.Replace("+", "")
                    Else
                        PersoonBedrag = txtBedrag.Text
                    End If
                    Personen(index) = split(0) & ";" & Persoonnaam & ";" & PersoonBedrag
                    txtKlantcode_TextChanged()
                    MessageBox.Show("Succesvol opgeslagen")
                    Exit For
                End If

            Next
            'Als er geen gelijkaardige code is maakt hij een nieuwe aan met dat bedrag
            If Persoonnaam = "Niet gevonden" Then
                Personen.Add(split(0) & ";X;" & PersoonBedrag)
            End If
        Catch ex As Exception
            MessageBox.Show("Er zijn ongeldige of onbestaande waarden gevonden." & ex.ToString)
        End Try

    End Sub

    Private Sub btnSaveMunten_Click(sender As Object, e As EventArgs) Handles btnSaveMunten.Click
        Munten(0) = num2.Value
        Munten(1) = num1.Value
        Munten(2) = num50.Value
        Munten(3) = num10.Value
        Munten(4) = num5.Value
    End Sub

    Private Sub btnMuntenTellen_Click(sender As Object, e As EventArgs) Handles btnMuntenTellen.Click
        Muntentellen()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        'De broodaanpassingen opslaan
        Try
            If (Not (numLocatie.Value < 1)) And numLocatie.Value - 1 < 16 And numAantal.Value > 0 Then
                'eerst de getallen omvormen naar het correcte formaat en dan opslaan als 1 string
                Locatie(numLocatie.Value - 1) = numAantal.Value & ";" & cbType.SelectedIndex & ";" & CentEuro(numPrijs.Value)
                numLocatie.Value = 0
                numAantal.Value = 0
                numPrijs.Value = 0
                cbType.SelectedIndex = 0
                MessageBox.Show("Succesvol opgeslagen.")
                Refresh()
            Else
                MessageBox.Show("Ongeldige waarden zijn ingegeven.")
            End If
        Catch
            MessageBox.Show("Deze locatie is niet beschikbaar of de ingegeven waarden zijn ongeldig.")
        End Try
        BroodRefresh()
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        Locatie.Clear()
        Dim x As Integer
        Do Until x = 15
            x = x + 1
            Locatie.Add("")
        Loop
        BroodRefresh()
    End Sub

    'De kleine knopjes op de machine.
    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub
    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub
    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub
    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub
    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub
    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        Try
            numLocatie.Value = numLocatie.Value * 10
        Catch
            MessageBox.Show("De waarde is the hoog.")
        End Try
    End Sub

End Class