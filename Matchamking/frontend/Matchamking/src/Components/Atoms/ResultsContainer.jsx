import React from 'react'
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
const ResultsContainer = () => {
  return (
    <StyledResultsContainer>
    </StyledResultsContainer>
  )
}

export default ResultsContainer