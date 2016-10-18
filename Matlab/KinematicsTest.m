syms w1;
syms w2;
syms w3;

AngVels = [1
           0
           0];

r = 0.1;
L = 0.2;

%syms r;
%syms L;

M = [0 -r/sqrt(3) r/sqrt(3)
     -2*r/3 r/3 r/3
     r/(3*L) r/(3*L) r/(3*L)];
 
Vels = M*AngVels
