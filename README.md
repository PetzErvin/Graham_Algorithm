# Algoritmul lui Graham. C# 

Acest cod implementează algoritmul lui Graham pentru a găsi învelișul convex al unui set de puncte pe un plan 2D. Setul de puncte este preluat dintr-un PictureBox. După ce algoritmul este aplicat punctelor, se desenează învelișul convex pe PictureBox, utilizând grafica din C#.

Algoritmul începe prin găsirea punctului cu cea mai mică coordonată Y, iar în caz de egalitate, punctul cu cea mai mică coordonată X. Apoi, punctele sunt sortate în ordinea unghiului pe care îl fac cu linia orizontală care trece prin p0. Punctele care ar face un unghi mai mare sau egal cu 180 de grade față de segmentul anterior sunt eliminate, astfel încât învelișul convex să fie format numai din puncte la stânga segmentelor.

În cele din urmă, se desenează punctele în negru și invelișul convex în albastru pe PictureBox. Această implementare poate fi îmbunătățită prin adăugarea de funcții pentru a adăuga, șterge și reseta punctele din PictureBox.


 # Algoritmul Graham Scan funcționează astfel: 
(pas cu pas)

1.Se selectează punctul cu cea mai mică valoare a coordonatei y și, în caz de egalitate, cu cea mai mică valoare a coordonatei x.

2.Se sortează celelalte puncte în ordinea crescătoare a unghiului pe care îl fac cu punctul selectat la primul pas.

3.Se alege primul punct din lista sortată și se adaugă într-o listă goală de puncte, numită acoperirea convexă.

4.Se iau următoarele puncte din lista sortată și se verifică dacă acestea fac o întoarcere la stânga sau la dreapta cu privire la ultimele două puncte adăugate în acoperirea convexă.

5.Dacă următorul punct face o întoarcere la stânga, se adaugă în acoperirea convexă și se trece la următorul punct. Dacă următorul punct face o întoarcere la dreapta, se elimină ultimul punct adăugat în acoperirea convexă și se revine la pasul 4 pentru a verifica următorul punct.

6.Algoritmul se oprește când toate punctele au fost verificate și se obține acoperirea convexă a setului de puncte.

În esență, algoritmul Graham Scan selectează un punct de pornire și apoi sortează restul punctelor în ordine crescătoare a unghiurilor pe care le fac cu punctul de pornire. Apoi, începând cu cel de-al doilea punct din lista sortată, algoritmul verifică dacă adăugarea lui ar face o întoarcere la stânga sau la dreapta. Punctele care fac o întoarcere la dreapta sunt eliminate din acoperirea convexă, iar punctele care fac o întoarcere la stânga sunt adăugate. După ce s-au verificat toate punctele, acoperirea convexă a setului de puncte este formată din punctele rămase în lista acoperirii convexe.
