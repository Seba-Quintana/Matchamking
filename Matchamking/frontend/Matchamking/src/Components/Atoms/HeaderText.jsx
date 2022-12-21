import React from 'react'
import styled from 'styled-components'

const StyleHeaderText = styled.div`
@media (max-width: 800px){
    font-family: 'Inter', sans-serif;
    font-size: 20px;
    color: white;
    justify-content: left;
    align-self: flex-start;
    padding-left: 10%;
    display: flex;
}
@media (min-width: 800px){
    font-family: 'Inter', sans-serif;
    font-size: 20px;
    color: white;
    align-self: center;
    display: flex;
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