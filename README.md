# AdvancedRot13
Simple algorithm to encode strings. Symmetric encode/decode.

Written in F# with Visual Studio 2017.

Advanced Rot-13 uses a rolling rotation algorithm.
Each character is rotated by the preceding character.
It uses mod27 to allow spaces. All lowercase.

You can pass `encode` or `decode` as command line parameters.
Default is encode. Other parameters kill the program.
