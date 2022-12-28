import React from 'react'
import crown from '../../assets/bxs-crown.svg'
import styled from 'styled-components'
import MiddleButtonStyle from './MiddleButtonStyle'

const Text = styled.div`
    @media (max-width: 800px){
        display: none;
    }
    font-family: 'Inter', sans-serif;
    color: white;
    margin-right: 1rem;
`

const MatchmakeButton = () => {
  return (
    <MiddleButtonStyle>
        <Text> Matchmaking!</Text>
        <img src={crown}></img>
    </MiddleButtonStyle>
  )
}

export default MatchmakeButton