import React, { useEffect } from 'react'
import ResultsContainer from '../Atoms/ResultsContainer'
import PlayerSearchBar from '../Molecules/PlayerSearchBar'
import PlayerSelect from '../Molecules/PlayerResults'
import { useState } from 'react'
import PlayerResults from '../Molecules/PlayerResults'
import PlayersSelected from '../Molecules/PlayersSelected'
import styled from 'styled-components'

const StyledResultsContainer = styled.div`
  background-color: white;
  width: 90%;
  height: 70%;
  align-items: center;
  flex-direction: column;
  margin-top: 1rem;
  margin-bottom: 1rem;
  border-radius: 5px;
  max-width: 500px;
  overflow-y: auto;
  max-height: 400px;
`


const MatchmakingManagement = () => {

  const [players, setPlayers] = useState([])
  const [remainingPlayers, setRemainingPlayers] = useState([])
  const [selectedPlayers, setSelectedPlayers] = useState([])
  const playersList = [
    {
      playername: 'Diekkan',
      winrate: '50%'
    },
    {
      playername: 'Kaneki',
      winrate: '80%'
    },
    {
      playername: 'Emiliardo',
      winrate: '50%'
    },
    {
      playername: 'N8',
      winrate: '80%'
    },
    {
      playername: 'NachoPuto',
      winrate: '50%'
    },
    {
      playername: 'Juanma',
      winrate: '80%'
    },
    {
      playername: 'Seba',
      winrate: '80%'
    },
]

  useEffect(() => {
  setRemainingPlayers(playersList);
  }, [])

  return (
    <>
        <PlayerSearchBar></PlayerSearchBar>
        <StyledResultsContainer>
          <PlayersSelected 
            selectedPlayers={selectedPlayers}
            setSelectedPlayers={setSelectedPlayers}
            remainingPlayers={remainingPlayers}
            setRemainingPlayers={setRemainingPlayers}
          ></PlayersSelected>
          <PlayerResults
            selectedPlayers={selectedPlayers}
            setSelectedPlayers={setSelectedPlayers}
            remainingPlayers={remainingPlayers}
            setRemainingPlayers={setRemainingPlayers}
          ></PlayerResults>
        </StyledResultsContainer>
    </>
    )
}

export default MatchmakingManagement