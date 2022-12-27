import React, { useEffect, useState } from 'react'
import ResultsContainer from '../Atoms/ResultsContainer'
import Player from '../Atoms/Player'
import styled from 'styled-components'

const StyledResultsContainer = styled.div`
    background-color: white;
    width: 90%;
    height: 70%;
    display: flex;
    align-items: center;
    flex-direction: column;
    margin-top: 1rem;
    border-radius: 5px;
    max-width: 500px;
    overflow: scroll;
    max-height: 400px;
`

const PlayerResults = ({remainingPlayers, setSelectedPlayers}) => {

    useEffect(() => {
        console.log(players)
    }, [players.length])
  return (
    <>
        <StyledResultsContainer>
            <Player winrate="50%" playername="Diekkan"
            players={players} setPlayers={setPlayers}></Player>
        {
            remainingPlayers.map(item => 
                <Player winrate={item.winrate}
                    playername={item.playername}
                    players={remainingPlayers}
                    setPlayers={setSelectedPlayers}
                ></Player>
        )}
        </StyledResultsContainer>
    </>
  )
}

export default PlayerResults