import React from 'react'
import styled from 'styled-components'

const StyleHeaderText = styled.div`
@media (max-width: 800px){
    font-family: 'Inter', sans-serif;
    font-size: 20px;
    color: white;
    justify-content: left;
    align-self: flex-start;
    padding-left: 1rem;
    display: flex;
    margin-top: 1.5rem
}
@media (min-width: 500px){
    font-family: 'Inter', sans-serif;
    font-size: 20px;
    color: white;
    align-self: center;
    display: flex;
}
@media (max-height: 580px){
    font-family: 'Inter', sans-serif;
    font-size: 20px;
    color: white;
    display: flex;
    align-self: center;
}
`
const HeaderText = ({text}) => {
  return (
    <StyleHeaderText>
        {text}
    </StyleHeaderText>
  )
}

export default HeaderText