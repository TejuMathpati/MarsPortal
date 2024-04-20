Feature: This feature file contains test cases for Skills feature of Mars portal

Scenario Outline: This test is to verify user is able to add Skills record
Given User signin into Mars Portal <email> <password>
When User clicks on skills tab and enters Skill Name and Skill level <skill> <level>
Then The Skill gets added into user profile <skill>

Examples: 
| email | password | skill | level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'C#'| 2 |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'Testing'| 1 |

Scenario Outline: Verify that user can not add duplicate skill name
Given User signin into Mars Portal <email> <password>
When User can not add duplicate skill name <skill> <level> 
Examples: 
| email | password | skill | level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'| 'C#'| 2 |

Scenario Outline: This is to verify that user can update the skills that has entered already
Given User signin into Mars Portal <email> <password> 
When user updates skill name and level <skill> <level>
Then The skill gets updated into users profile <skill>
Examples: 
| email                     | password          | skill | level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a' | 'Sharepoint updated' | 2	|

Scenario Outline: This test is to verify that user can delete the added skill
Given User signin into Mars Portal <email> <password>
When user deletes the skills
Then The skills gets deleted from the users profile <skill>
Examples: 
| email                     | password          | skill |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a' | 'Specflow updated' |

Scenario Outline: This test is to verify that "Add Skills" textbox can not be left empty when user adds the skills
Given User signin into Mars Portal <email> <password>
When User can not add skill without skill name <level>
Examples: 
| email | password |  level |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'|  2 |

Scenario Outline: This test is to verify that user is can not add skills without selecting the skill level
Given User signin into Mars Portal <email> <password>
When User can not add skill without skill level <skill>
Examples: 
| email | password |  skill |
| 'teju.mathpati@gmail.com' | '84rUmsQcr6ha27a'|  'Python' |