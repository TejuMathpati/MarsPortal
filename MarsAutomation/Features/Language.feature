Feature: This feature file contains test cases for Language feature of Mars portal
1. Add new language
2. Update the languge
3. Delete language
4. Verify user cannot add duplicate language name
5. Verify user can aad maximum 4 languages

Scenario Outline: A: This test is to verify that user is able to add new language in to his profile
Given User signin into Mars Portal <email> <password>
When User enters Language Name and Language level <language> <level>
Then The language gets added into user profile <language>
Examples: 
| email | password | language | level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'French'| 2 |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'Russian'| 2 |


Scenario Outline: B: This is to verify that user can update the language that has entered already
Given User signin into Mars Portal <email> <password> 
When user updates language name and level <language> <level>
Then The language gets updated into users profile <language>
Examples: 
| email                     | password          | language | level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a' | 'English Updated' | 2	   |


Scenario Outline: C: This test is to verify that user can delete the added language 
Given User signin into Mars Portal <email> <password>
When user deletes the language 
Then The language gets deleted from the users profile <language>
Examples: 
| email                     | password          | language |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a' | 'French'   |

Scenario Outline: D: This test is to verify that language can not be added twice 
Given User signin into Mars Portal <email> <password>
When User enters Language duplicate Name and Language level system generates error message <language> <level> 

Examples: 
| email | password | language | level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'English'| 2 |

Scenario Outline: E: This test is to verify that user can add maximum 4 languages to his profile
Given User signin into Mars Portal <email> <password>
When User enters four languages
Then After adding four languages user is not able to add more languages <language> <level>
Examples:
| email | password | language | level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'French' | 2 |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'Russian'| 2 |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'English'| 3 |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'Hindi'  | 2 |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'Arebic' | 2 |

Scenario Outline: This test is to verify that "Add language" textbox can not be left empty when user adds the language
Given User signin into Mars Portal <email> <password>
When User add language without language name then system generates an error <level>
Examples: 
| email | password |  level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'|  2 |

Scenario Outline: This test is to verify that user is can not add language without selecting the level
Given User signin into Mars Portal <email> <password>
When User add language without level then system generates an error message <language>
Examples: 
| email | password |  language |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'|  'Manderin' |