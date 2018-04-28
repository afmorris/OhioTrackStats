grammar HyTek;

init
: event+;

event
: eventInfo NEWLINE eventResult+ NEWLINE;

eventInfo
: eventGender eventName ;

eventGender
: (GIRLS|BOYS) ;

eventName
: (ID|number)+;

columnHeadersf
: (ID|number)+;

eventResult
: individualResult
  | throwawayResult
  | relayResult;

individualResult
: place jerseyNumber? athleteName athleteYear? schoolName seed? NUMBERSIGN? performance metric? wind? heatNumber? dqReason? points? tiebreaker? NEWLINE trials? heightResults?;

throwawayResult
: place jerseyNumber? athleteName athleteYear? schoolName NEWLINE;

trials
: performance+ NEWLINE?;

heightResults
: (PASS | CLEAR | FAIL)+ NEWLINE;

relayResult
: place schoolName seed? performance metric? wind? heatNumber? dqReason? points? tiebreaker? NEWLINE legInfo? NEWLINE;

metric
: foot DOT inch METERS;

wind
: NOWIND
  | DASH? number (DOT number)?;

legInfo
: leg leg NEWLINE leg leg;

leg
: legNumber RPAREN jerseyNumber? athleteName athleteYear?;

legNumber
: number;

place
: number | DQPLACE;

jerseyNumber
: NUMBERSIGN? number;

athleteName
: words (DASH words)? (APOSTROPHE words)?;

athleteYear
: number;

schoolName
: words;

seed
: time
  | distance
  | dq;

time
: (minute COLON)? second DOT decimal;

distance
: foot DASH inch DOT? decimal?;

dq : FALSESTART | NOHEIGHT | DISQUALIFIED | FOUL | NOTIME | DIDNOTFINISH | DISQUALIFIED INTERFERENCE | SCRATCH | NODISTANCE;

dqReason
: OUTOFZONE;

performance
: TIE? time QUALIFY? RECORD? NUMBERSIGN?
  | TIE? distance QUALIFY? RECORD? NUMBERSIGN?
  | dq;

heatNumber
: number;

points
: number;

tiebreaker
: time
  | distance;

hour
: INTEGER_NUMBER;

minute
: INTEGER_NUMBER;

second
: INTEGER_NUMBER;

decimal
: INTEGER_NUMBER;

period
: (AM|PM);

day
: INTEGER_NUMBER;

month
: INTEGER_NUMBER;

year
: INTEGER_NUMBER;

date
: month SLASH day SLASH year;

clockTime
: hour COLON minute COLON? second? period;

foot
: INTEGER_NUMBER;

inch
: INTEGER_NUMBER;

number
: INTEGER_NUMBER;

words
: ID*;

WS : [ \t]+ -> skip ;
ATSIGN: '@' -> skip;
SEMICOLON: ';' -> skip;
TOPINFO: LICENSEDTO .* RESULTS .*? NEWLINE .*? NEWLINE -> skip;
SEPARATOR: '='+ .*? '='+ NEWLINE -> skip;
FINALSKIP: FINALS NEWLINE -> skip;
PRELIMS: PRELIMINARIES NEWLINE -> skip;
NOWINDPARENS: '(NWI)' -> skip;
EVENTNUMBER: EVENT .*? [0-9]+ -> skip;
LICENSEDTO: 'Licensed to';
RESULTS: 'Results';
EVENT: 'Event';

INTEGER_NUMBER
: DIGIT+;

fragment
DIGIT : ('0'..'9');


GIRLS: 'Girls';
BOYS: 'Boys';
FINALS: 'Finals';
PRELIMINARIES: 'Preliminaries';
DOT: '.';
METERS: 'm';
NOWIND: 'NWI';
LPAREN: '(';
RPAREN: ')';
DASH: '-';
APOSTROPHE: '\'';
COLON: ':';
FALSESTART: 'FS';
NOHEIGHT: 'NH';
DISQUALIFIED: 'DQ';
FOUL: 'FOUL';
NOTIME: 'NT';
DIDNOTFINISH: 'DNF';
INTERFERENCE: 'Interference';
TIE: 'J';
AM: 'AM';
PM: 'PM';
SLASH: '/';
NUMBERSIGN: '#';
QUALIFY: [qQ];
RECORD: 'A' | 'R';
PASS: 'P'+;
FAIL: 'X'+;
CLEAR: 'X'* 'O'+;
OUTOFZONE: 'Out of Zone';
SCRATCH: 'SCR';
NODISTANCE: 'ND';

DQPLACE : '--' ;

INT : [0-9]+ ;
ID  : [a-zA-Z"#'.\-:,()’ć]+ ;
NEWLINE : '\r'? '\n' ;