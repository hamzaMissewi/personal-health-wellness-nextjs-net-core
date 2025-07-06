"use client"

import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"
import { Button } from "@/components/ui/button"
import { BarChart, TrendingUp, AlertTriangle, CheckCircle, Brain, Activity } from "lucide-react"

export function HealthInsights() {
  const insights = [
    {
      type: "positive",
      title: "Sleep Pattern Improvement",
      description:
        "Your sleep consistency has improved by 23% over the past month. You're averaging 7.5 hours per night.",
      impact: "High",
      category: "Sleep",
      recommendation: "Continue your current bedtime routine and consider adding a 10-minute wind-down period.",
    },
    {
      type: "warning",
      title: "Hydration Inconsistency",
      description: "You've missed your daily water intake goal 4 out of the last 7 days.",
      impact: "Medium",
      category: "Hydration",
      recommendation: "Set hourly reminders and keep a water bottle visible throughout the day.",
    },
    {
      type: "positive",
      title: "Exercise Streak",
      description: "You've maintained consistent physical activity for 12 consecutive days!",
      impact: "High",
      category: "Fitness",
      recommendation: "Great job! Consider gradually increasing intensity or trying new activities.",
    },
    {
      type: "neutral",
      title: "Stress Level Analysis",
      description:
        "Your stress indicators show moderate levels during weekdays, with significant improvement on weekends.",
      impact: "Medium",
      category: "Mental Health",
      recommendation: "Implement midweek stress-relief activities like short meditation sessions.",
    },
  ]

  const healthTrends = [
    { metric: "Average Heart Rate", trend: "down", value: "68 bpm", change: "-3 bpm", period: "vs last month" },
    { metric: "Daily Steps", trend: "up", value: "9,234", change: "+1,456", period: "vs last month" },
    { metric: "Sleep Quality Score", trend: "up", value: "8.2/10", change: "+0.8", period: "vs last month" },
    { metric: "Stress Level", trend: "down", value: "3.1/10", change: "-1.2", period: "vs last month" },
  ]

  const mlPredictions = [
    {
      title: "Optimal Workout Time",
      prediction: "Based on your energy patterns, 7:30 AM is your peak performance window",
      confidence: 87,
    },
    {
      title: "Sleep Quality Forecast",
      prediction: "Tonight's sleep quality predicted to be 8.5/10 based on today's activities",
      confidence: 92,
    },
    {
      title: "Health Risk Assessment",
      prediction: "Low risk profile maintained. Continue current lifestyle patterns",
      confidence: 94,
    },
  ]

  return (
    <div className="space-y-6">
      <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
        <Card>
          <CardHeader>
            <CardTitle className="flex items-center space-x-2">
              <Brain className="h-5 w-5 text-purple-500" />
              <span>AI Health Insights</span>
            </CardTitle>
          </CardHeader>
          <CardContent className="space-y-4">
            {insights.map((insight, index) => (
              <div key={index} className="p-4 rounded-lg border">
                <div className="flex items-start justify-between mb-2">
                  <div className="flex items-center space-x-2">
                    {insight.type === "positive" && <CheckCircle className="h-5 w-5 text-green-500" />}
                    {insight.type === "warning" && <AlertTriangle className="h-5 w-5 text-yellow-500" />}
                    {insight.type === "neutral" && <Activity className="h-5 w-5 text-blue-500" />}
                    <h4 className="font-semibold text-gray-900">{insight.title}</h4>
                  </div>
                  <div className="flex space-x-2">
                    <Badge variant="outline" className="text-xs">
                      {insight.category}
                    </Badge>
                    <Badge
                      variant={
                        insight.impact === "High"
                          ? "destructive"
                          : insight.impact === "Medium"
                            ? "default"
                            : "secondary"
                      }
                      className="text-xs"
                    >
                      {insight.impact}
                    </Badge>
                  </div>
                </div>
                <p className="text-sm text-gray-700 mb-3">{insight.description}</p>
                <div className="p-3 bg-gray-50 rounded-lg">
                  <p className="text-xs font-medium text-gray-900 mb-1">Recommendation:</p>
                  <p className="text-xs text-gray-700">{insight.recommendation}</p>
                </div>
              </div>
            ))}
          </CardContent>
        </Card>

        <Card>
          <CardHeader>
            <CardTitle className="flex items-center space-x-2">
              <TrendingUp className="h-5 w-5 text-green-500" />
              <span>Health Trends</span>
            </CardTitle>
          </CardHeader>
          <CardContent className="space-y-4">
            {healthTrends.map((trend, index) => (
              <div key={index} className="flex items-center justify-between p-3 bg-gray-50 rounded-lg">
                <div>
                  <p className="font-medium text-gray-900">{trend.metric}</p>
                  <p className="text-2xl font-bold text-gray-900">{trend.value}</p>
                </div>
                <div className="text-right">
                  <div
                    className={`flex items-center space-x-1 ${
                      trend.trend === "up" ? "text-green-600" : "text-red-600"
                    }`}
                  >
                    <TrendingUp className={`h-4 w-4 ${trend.trend === "down" ? "rotate-180" : ""}`} />
                    <span className="font-medium">{trend.change}</span>
                  </div>
                  <p className="text-xs text-gray-600">{trend.period}</p>
                </div>
              </div>
            ))}
          </CardContent>
        </Card>
      </div>

      <Card>
        <CardHeader>
          <CardTitle className="flex items-center space-x-2">
            <BarChart className="h-5 w-5 text-blue-500" />
            <span>Machine Learning Predictions</span>
          </CardTitle>
        </CardHeader>
        <CardContent>
          <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
            {mlPredictions.map((prediction, index) => (
              <div key={index} className="p-4 bg-gradient-to-br from-blue-50 to-purple-50 rounded-lg">
                <h4 className="font-semibold text-gray-900 mb-2">{prediction.title}</h4>
                <p className="text-sm text-gray-700 mb-3">{prediction.prediction}</p>
                <div className="flex items-center justify-between">
                  <span className="text-xs text-gray-600">Confidence</span>
                  <Badge variant="secondary" className="bg-green-100 text-green-800">
                    {prediction.confidence}%
                  </Badge>
                </div>
              </div>
            ))}
          </div>
          <div className="mt-6 p-4 bg-yellow-50 rounded-lg">
            <p className="text-sm text-yellow-800">
              <strong>Note:</strong> These predictions are based on machine learning analysis of your historical health
              data and behavioral patterns. Always consult with healthcare professionals for medical decisions.
            </p>
          </div>
        </CardContent>
      </Card>

      <div className="flex justify-center">
        <Button
          size="lg"
          className="bg-gradient-to-r from-blue-500 to-purple-600 hover:from-blue-600 hover:to-purple-700"
        >
          Generate Detailed Health Report
        </Button>
      </div>
    </div>
  )
}
