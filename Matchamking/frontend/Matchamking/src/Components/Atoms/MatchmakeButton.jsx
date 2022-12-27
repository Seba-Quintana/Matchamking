import React from 'react'
import crown from '../../assets/bxs-crown.svg'
import styled from 'styled-components'

const MakeMatch = styled.div`
    background-color: #f55252;
    width: 90%;
    max-width: 500px;
    height: 50px;
    display: flex;
    align-items: center;
    justify-content: center;
    border-radius: 5px;
    @media (max-width: 800px){
    align-self: center;
}
`
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
    <MakeMatch>
        <Text> Matchmaking!</Text>
        <img src={crown}></img>
    </MakeMatch>
  )
}

export default MatchmakeButton